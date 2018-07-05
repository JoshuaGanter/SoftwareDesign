using System;
using System.Linq;

namespace ChaosOffice
{
    public class Player : Actor
    {
        private static Player _instance;
        
        public static Player Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Player();
                }
                return _instance;
            }
        }

        public Room CurrentRoom
        {
            get
            {
                return _currentRoom;
            }
        }

        private Player() : base("You", "", 100, 10, 10)
        {
            // init
        }

        public void SpeakTo(string characterName)
        {
            if (_currentRoom.Creatures.Contains(characterName))
            {
                // init dialog
            }
            else
            {
                Say("Can't find that character here..");
            }
        }

        public void GoTo(string direction)
        {
            if (_currentRoom.Connections.ContainsKey(direction))
            {
                Door door = _currentRoom.Connections[direction];
                if (door.Key != null)
                {
                    if (!Inventory.Contains(door.Key.Name))
                    {
                        Console.WriteLine(door.LockedMessage);
                        return;
                    }
                }
                EnterRoom(door.NextRoom);
            }
            else
            {
                Say("There seems to be no exit there.");
            }
        }

        public override void EnterRoom(Room room)
        {
            _currentRoom = room;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" " + room.Name + " ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(room.Description);
        }

        public void Attack(string targetName)
        {
            if (_currentRoom.Creatures.Contains(targetName))
            {
                // engage fight
            }
            else
            {
                Say("I can't attack that.");
            }
        }

        public void LookAt(string targetName)
        {
            if (targetName == "")
            {
                Console.WriteLine("You see:");
                foreach (Item item in _currentRoom.Items)
                {
                    Console.WriteLine("- " + item.Name);
                }
            }
            else
            {
                EntityList<Entity> roomEntities = _currentRoom.GetAllEntities();
                if (roomEntities.Contains(targetName))
                {
                    Console.WriteLine(roomEntities.Get(targetName).Description);
                }
                else if (_currentRoom.Connections.ContainsKey(targetName))
                {
                    Console.WriteLine(_currentRoom.Connections[targetName].Description);
                }
                else
                {
                    Say("Where should I look at?");
                }
            }
        }

        public void PrintInventory()
        {
            if (Inventory.Count != 0)
            {
                foreach(Item item in Inventory)
                {
                    Console.WriteLine("- " + item.Name);
                }
            }
            else
            {
                Say("I have nothing with me.");
            }
        }

        public void PickDialogLine(string line)
        {
            // pick next dialog line
        }
    }
}