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
        public GameStates GameState {get; private set;}
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
            Console.WriteLine("It is late afternoon and you are tirelessly working on a game for weeks now. A critical bug is still in the game and you can't find a way to fix it.");
            Console.Write("Just now your colleague sent you an email that he fixed the bug. You have to get to his office and receive the ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Mighty Saviour");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" with the code fixing the issue.");
            Console.WriteLine("But be aware, there may be challenges to master, fears to overcome and enemies to fight on your journey..");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void Play()
        {
            Room startingRoom = World.Build();
            PrintIntroduction();
            Player.Instance.EnterRoom(startingRoom);
            IsRunning = true;
            while(IsRunning)
            {
                Console.Write(": ");
                PlayerCommand command = CommandParser.ParseCommand(Console.ReadLine());
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
                        Player.Instance.GoTo(command.Parameter);
                        break;
                    case "l":
                    case "look":
                        Player.Instance.LookAt(command.Parameter);
                        break;
                    case "i":
                    case "inventory":
                        Player.Instance.PrintInventory();
                        break;
                    case "t":
                    case "take":
                        Player.Instance.TakeItem(command.Parameter);
                        break;
                    case "d":
                    case "drop":
                        Player.Instance.DropItem(command.Parameter);
                        break;
                    case "a":
                    case "attack":
                        Player.Instance.Attack(command.Parameter);
                        break;
                    case "s":
                    case "speak":
                        Player.Instance.SpeakTo(command.Parameter);
                        break;
                    case "c":
                    case "consume":
                        Player.Instance.ConsumeItem(command.Parameter);
                        break;
                    case "b":
                    case "beat":
                        Player.Instance.BeatTarget(command.Parameter);
                        // finish fighting round
                        break;
                    case "w":
                    case "wait":
                        // finish fighting round
                        break;
                    case "p":
                    case "pick":
                        Player.Instance.PickDialogLine(command.Parameter);
                        break;
                    case "":
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}