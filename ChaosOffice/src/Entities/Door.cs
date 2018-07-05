namespace ChaosOffice
{
    public class Door : Entity
    {
        public Key Key {get; private set;}
        public Room NextRoom {get; private set;}
        public string LockedMessage {get; private set;}
        
        public Door(string name, string description, Room nextRoom, Key key = null, string lockedMessage = "This door is locked.") : base(name, description)
        {
            NextRoom = nextRoom;
            Key = key;
            LockedMessage = lockedMessage;
        }
    }
}