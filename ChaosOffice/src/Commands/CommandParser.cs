using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChaosOffice
{
    public static class CommandParser
    {
        public static PlayerCommand ParseCommand(string input)
        {
            string[] splitted = input.Split(' ', 2);
            string command = splitted[0];
            string parameter = "";
            if (splitted.Length == 2)
            {
                parameter = splitted[1];
            }
            return new PlayerCommand(command, parameter);
        }
    }
}