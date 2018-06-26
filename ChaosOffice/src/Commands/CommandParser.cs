using System;

namespace ChaosOffice
{
    public static class CommandParser
    {
        private static ValidCommand[] _validCommands = new ValidCommand[]
        {
            new ValidCommand("help", "h", "", new GameState[]{GameState.Adventure, GameState.Dialog, GameState.Fight}, "[help|h]", "List of commands you can use")
        };

        public static void PrintValidCommands()
        {
            throw new NotImplementedException();
            // print all commands out of _validCommands
        }

        public static Command ParseCommand(string input)
        {
            throw new NotImplementedException();
            // parse the incoming command
            // throw FormatException() if command cannot be parsed, or
            // throw InvalidOperationException() if command is not available in current GameState
        }

        /*private static void PrintHelp()
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
        }*/
    }
}