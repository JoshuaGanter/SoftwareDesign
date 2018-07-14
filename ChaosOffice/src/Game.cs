using System;
using System.Collections.Generic;

namespace ChaosOffice
{
    class Game
    {
        private static Game _instance;
        
        public static Game Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                }
                return _instance;
            }
        }

        public bool IsRunning {get; private set;}
        public GameStates GameState;
        static void Main(string[] args)
        {
            Game.Instance.Play();
        }

        private Game()
        {
            GameState = GameStates.Adventure;
        }

        private void PrintIntroduction()
        {
            WriteLine("It is late afternoon and you are tirelessly working on a game for weeks now. A critical bug is still in the game and you can't find a way to fix it.");
            Write("Just now your colleague sent you an email that he fixed the bug. You have to get to his office and receive the ");
            Write("Mighty Saviour", ConsoleColor.Yellow);
            WriteLine(" with the code fixing the issue.");
            WriteLine("But be aware, there may be challenges to master, fears to overcome and enemies to fight on your journey..");
            WriteLine();
            WriteLine("[Continue]");
            Console.ReadKey(true);
        }

        public void Play()
        {
            Room startingRoom = World.Build();
            PrintIntroduction();
            Player.Instance.EnterRoom(startingRoom);
            IsRunning = true;
            while(IsRunning)
            {
                Console.Write("> ");
                PlayerCommand command;
                command = CommandParser.ParseCommand(Console.ReadLine());
                switch (command.Command)
                {
                    case "h":
                    case "help":
                        Console.WriteLine("help (h), exit (e), go (g), look (l), inventory (i), take (t), drop (d), attack (a), speak (s), consume (c), hit (h), wait (w), pick (p)");
                        break;
                    case "e":
                    case "exit":
                        IsRunning = false;
                        break;
                    case "g":
                    case "go":
                        if (CheckGameState(GameStates.Adventure))
                        {
                            Player.Instance.GoTo(command.Parameter);
                        }
                        break;
                    case "l":
                    case "look":
                        if (CheckGameState(GameStates.Adventure))
                        {
                            Player.Instance.LookAt(command.Parameter);
                        }
                        break;
                    case "i":
                    case "inventory":
                        Player.Instance.PrintInventory();
                        break;
                    case "t":
                    case "take":
                        if (CheckGameState(GameStates.Adventure))
                        {
                            Player.Instance.TakeItem(command.Parameter);
                        }
                        break;
                    case "d":
                    case "drop":
                        if (CheckGameState(GameStates.Adventure))
                        {
                            Player.Instance.DropItem(command.Parameter);
                        }
                        break;
                    case "a":
                    case "attack":
                        if (CheckGameState(GameStates.Adventure))
                        {
                            Player.Instance.Attack(command.Parameter);
                        }
                        break;
                    case "s":
                    case "speak":
                        if (CheckGameState(GameStates.Adventure))
                        {
                            Player.Instance.SpeakTo(command.Parameter);
                        }
                        break;
                    case "c":
                    case "consume":
                        if (CheckGameState(GameStates.Adventure | GameStates.Fight))
                        {
                            Player.Instance.ConsumeItem(command.Parameter);
                        }
                        break;
                    case "b":
                    case "beat":
                        if (CheckGameState(GameStates.Fight))
                        {
                            Player.Instance.BeatTarget(command.Parameter);
                        }
                        break;
                    case "w":
                    case "wait":
                        if (CheckGameState(GameStates.Fight))
                        {
                            FinishFightingRound();
                        }
                        break;
                    case "p":
                    case "pick":
                        if (CheckGameState(GameStates.Dialog))
                        {
                            Player.Instance.PickDialogLine(command.Parameter);
                        }
                        break;
                    case "":
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }

                if (Player.Instance.Health <= 0)
                {
                    WriteLine("On your journey to find the fix for your code, you were defeated. Your blood now sprinkles the walls in the office. After a short time you are forgotten and replaced.");
                    WriteLine("GAME OVER", ConsoleColor.Red);
                    IsRunning = false;
                }

                if (Player.Instance.Inventory.Contains("mighty saviour"))
                {
                    WriteLine("You've overcome all the challenges drawn to you. You received the Mighty Saviour, held in the claws of a lost individual. But once you've put the USB flash drive in to your computer, everything turns black. Black as the darkest night..");
                    IsRunning = false;
                }
            }
            WriteLine();
            WriteLine("[Close]");
            Console.ReadKey(true);
        }

        public void FinishFightingRound()
        {
            Creature enemy = Player.Instance.CurrentTarget;
            if (enemy.Health > 0)
            {
                enemy.BeatTarget();
            }
            else
            {
                GameState = GameStates.Adventure;
                Player.Instance.CurrentTarget = null;
                enemy.CurrentTarget = null;
            }
        }

        public bool CheckGameState(GameStates gameStates)
        {
            if ((GameState & gameStates) != 0)
            {
                return true;
            }
            else
            {
                Player.Instance.Say("I can't do that now.");
                return false;
            }
        }

        public static void Write(string words, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(words);
        }

        public static void WriteLine(string words = "", ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(words);
        }
    }
}