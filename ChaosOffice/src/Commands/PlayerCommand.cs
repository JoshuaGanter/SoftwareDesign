namespace ChaosOffice
{
    public struct PlayerCommand
    {
        public string Command {get; private set;}
        public string Parameter {get; private set;}
        
        public PlayerCommand(string command, string parameter)
        {
            Command = command;
            Parameter = parameter;
        }
    }
}