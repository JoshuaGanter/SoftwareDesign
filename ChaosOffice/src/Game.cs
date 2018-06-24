using System;
using System.Collections.Generic;

namespace ChaosOffice
{
    /// <summary>The main class for this program.</summary>
    class Game
    {
        static void Main(string[] args)
        {
            PrintHelp();
        }

        /// <summary>Prints a list of available commands to the console.</summary>
        private static void PrintHelp()
        {
            string[] commands = new string[]
            {
                "help ......................... List of commands you can use",
                "quit ......................... Leave the game",
                "go <direction> ............... Go in a direction (north, east, south, west)",
                "look [at] <entity,direction> . Look in a specified direction or at an entity",
                "inventory .................... List the items in your inventory",
                "take <item> .................. Take an item",
                "drop <item> .................. Drop an item",
                "attack <creature> ............ Attack a creature",
                "speak [to] <character> ....... Speak to a character",
                "use <item> [on <entity>] ..... Use an item [on an entity]",
                "hit [with] [<item>] .......... Hit the enemy [with an item]",
                "flee ......................... Try to get away",
                "wait ......................... Pass your current turn",
                "pick <dialog_option> ......... Select the dialog option"
            };

            Console.WriteLine("You may use one of the following commands:");
            foreach (string command in commands)
            {
                Console.Write("- ");
                char[] letters = command.ToCharArray();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(letters[0]);
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 1; i < letters.Length; i++)
                {
                    if (letters[i] == '[' || letters[i] == '.')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.Write(letters[i]);
                    if (letters[i] == ']' || letters[i] == '.')
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }


            /*Test2 aTest = new Test2("a", (Test self, Test target) => {Console.WriteLine("Used " + self.AString + " with " + target.AString); return true;});
            aTest._onUse = (Test self, Test target) => {Console.WriteLine("Used " + self.AString + " with " + target.AString);};
            aTest.OnUse(new Test("b"));*/
    public class Test
    {
        public string AString {get; protected set;}
        private UseItemEventHandler _onUse;
        public Test(string a)
        {
            AString = a;
        }
        public Test(string a, UseItemEventHandler onUse) : this(a)
        {
            _onUse = onUse;
        }
        public delegate bool UseItemEventHandler(Test self, Test target);
        public void OnUse(Test target)
        {
            if (_onUse != null)
            {
                System.Console.WriteLine(_onUse(this, target).ToString());
            }
        }
    }

    class Test2 : Test
    {
        public Test2(string a) : base(a)
        {}

        public Test2(string a, UseItemEventHandler onUse) : base(a, onUse)
        {}
    }
}
