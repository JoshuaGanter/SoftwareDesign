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
            string[] splitted = input.ToLower().Split(' ', 2);
            string parameter = "";
            if (splitted.Length == 2)
            {
                parameter = splitted[1];
            }
            return new PlayerCommand(splitted[0], parameter);
        }
    }
}