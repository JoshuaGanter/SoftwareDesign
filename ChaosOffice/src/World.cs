namespace ChaosOffice
{
    public static class World
    {
        public static Room Build()
        {
            Item your_computer = new Item("your computer", "Your computer.", false);
            Item your_desk = new Item("your desk", "Your desk.", false);
            Item flyswatter = new Item("flyswatter", "A flyswatter. THE FLIES MAY DIE!!");
            Room your_office = new Room("Your office", "Description of your office.");
            your_office.Items.AddRange(new Item[] {your_computer, your_desk, flyswatter});

            Item fire_extinguisher = new Item("fire extinguisher", "A large thing you can put out fires with");
            Item jackets = new Item("jackets", "A few jackets.");
            Item broom = new Item("broom", "A broom to clean the floor.");
            Room hallway = new Room("Hallway", "Description of the hallway.");
            hallway.Items.AddRange(new Item[] {fire_extinguisher, jackets, broom});

            your_office.Connections.Add("east", new Door("Door to Hallway", "A solid wooden door.", hallway));
            hallway.Connections.Add("west", new Door("Door to your office", "A solid wooden door.", your_office));


            return your_office;
        }
    }
}