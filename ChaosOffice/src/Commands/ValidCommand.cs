namespace ChaosOffice
{
    public struct ValidCommand
    {
        public ValidCommand(string commandWord, string commandLetter, string parameters, GameState[] validInStates, string regex, string description)
        {
            CommandWord = commandWord;
            CommandLetter = commandLetter;
            Parameters = parameters;
            ValidInStates = validInStates;
            Regex = regex;
            Description = description;
        }
        public string CommandWord {get; private set;}
        public string CommandLetter {get; private set;}
        public string Parameters {get; private set;}
        public GameState[] ValidInStates {get; private set;}
        public string Regex {get; private set;}
        public string Description {get; private set;}
    }
}