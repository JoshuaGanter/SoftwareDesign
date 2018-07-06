namespace ChaosOffice
{
    public static class World
    {
        public static Room Build()
        {
            // Items
            Item your_computer = new Item("your computer", "Your computer.", false);
            Item your_desk = new Item("your desk", "Your desk.", false);
            Item flyswatter = new Item("flyswatter", "A flyswatter. THE FLIES MAY DIE!!");
            Item fire_extinguisher = new Item("fire extinguisher", "A large thing you can put out fires with");
            Item jackets = new Item("jackets", "A few jackets.");
            Item broom = new Item("broom", "A broom to clean the floor.");
            
            Character janitor = new Character
            (
                "Janitor",
                "The janitor cleaning the floor.",
                100,
                10,
                10,
                new DialogLayer[]
                {
                    new DialogLayer
                    {
                        Opening = "Hmpf.. What do you want?",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Ouh, sorry. Just wanted to pass by. <END>",
                                NextLayer = -1
                            },
                            new DialogOption
                            {
                                Sentence = "Why are you so grumpy?",
                                NextLayer = 1
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Why I'm grumpy? WHY I'M GRUMPY? Because I'm cleaning this damn floor and you just mess it all up again.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "I'm sorry.",
                                NextLayer = 2
                            },
                            new DialogOption
                            {
                                Sentence = "Then clean faster!",
                                NextLayer = 3
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Yeah.. whatever.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "<END>",
                                NextLayer = -1
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "B.. b.. but, I'm.. I'm cleaning as fast as I can. Nobody likes me, my wage is shit. I'm a loser.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Get your shit together, everyone's having problems. <END>",
                                NextLayer = -1
                            }
                        }
                    }
                }
            );

            // Rooms
            Room your_office = new Room("Your office", "Description of your office.");
            your_office.Items.AddRange(new Item[] {your_computer, your_desk, flyswatter});
            your_office.Creatures.AddRange(new Creature[] {janitor});

            Room hallway = new Room("Hallway", "Description of the hallway.");
            hallway.Items.AddRange(new Item[] {fire_extinguisher, jackets, broom});

            // Room connections
            your_office.Connections.Add("east", new Door("Door to Hallway", "A solid wooden door.", hallway));
            hallway.Connections.Add("west", new Door("Door to your office", "A solid wooden door.", your_office));

            return your_office;
        }
    }
}