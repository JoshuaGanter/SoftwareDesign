namespace ChaosOffice
{
    public struct Command
    {
        public Command(string commandWord, string[] parameters)
        {
            CommandWord = commandWord;
            Parameters = parameters;
        }
        public string CommandWord {get; private set;}
        public string[] Parameters {get; private set;}
        
    }
}