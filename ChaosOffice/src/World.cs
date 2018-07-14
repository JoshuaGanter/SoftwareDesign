using System;

namespace ChaosOffice
{
    public static class World
    {
        public static Room Build()
        {
            // Items
            Item computer = new Item("Computer", "Countless hours you've hacked code into this machine, but something just won't work. The email of your colleague is still opened:\nHey,\nI found the issue with your code. Come and pick up the fix at my office.\n\nGreets\nGabe", false);
            Item desk = new Item("Desk", "Your workplace for the most of the day. Staples of paper with UML diagramms on it cover the most of the desk's surface. Apart from that there's really only your monitor, keyboard and mouse on it.", false);
            Weapon flyswatter = new Weapon("Flyswatter", "A tool to slap these annoying animals. MAY THE FLIES DIE!", 1, 0, 20);

            Item umbrella = new Item("Umbrella", "Used by humans to shield themselves from the pouring rain.");
            Item jacket = new Item("Jacket", "A black softshell jacket. May be worn outside on cold or rainy days.");
            Item broom = new Item("Broom", "A long brown stick of wood with a brush at the end. Used to clean the floor.");

            Key building_plan = new Key("Building Plan", "A plan of the office building. You recognize all of the rooms. The ventilation shafts are mapped to.");
            ConsumeableItem coffee = new ConsumeableItem("Coffee", "A cup filled with pure, dark energy liquid.", 10);

            ConsumeableItem water = new ConsumeableItem("Water", "A bottle filled with nothing but pure water.", 10);
            Item magazine = new Item("Magazine", "A computer magazine. The title reads \"GameMeteorXL - Come Get Some! EXCLUSIVE: 10-page review and first-ever screenshots inside!\"");
            Key office_key = new Key("Office Key", "Key to your colleague's office.");

            Weapon knife = new Weapon("Knife", "A sharp knife to cut down all sorts of food. Can be practical in case of a zombie apocalypse.", 8, 2, 3);
            ConsumeableItem tea = new ConsumeableItem("Tea", "A cup filled with the mixture of hot water and tea. Very delicious.", 10);

            Item mighty_saviour = new Item("Mighty Saviour", "A USB flash drive with the words \"Mighty Saviour\" scatched in on it's surface.", true, ConsoleColor.Yellow);
            
            // Characters and Creatures
            Character todd_howard = new Character("Todd Howard", "The head of several departments in your company. He just holds a presentation telling the producers his vision of the next incarnation of Skyrim.", new DialogLayer[]
                {
                    new DialogLayer
                    {
                        Opening = "Don't you see that I'm holding a presentation? Leave.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Ouh, sorry. <END>",
                                NextLayer = -1
                            }
                        }
                    }
                }
            );
            Character ashley_cheng = new Character("Ashley Cheng", "One of the producers at your company. You barely know him.");
            Character craig_lafferty = new Character("Craig Lafferty", "One of the producers at you company. You barely know him.");
            Character phil_spencer = new Character("Phil Spencer", "Your boss. He looks anxious but also kind of angry, you should probably not upset him.", new DialogLayer[]
                {
                    new DialogLayer
                    {
                        Opening = "Yes?",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "You look troubled, what's up?",
                                NextLayer = 1
                            },
                            new DialogOption
                            {
                                Sentence = "Gabe found a fix for my code issue.",
                                NextLayer = 2
                            },
                            new DialogOption
                            {
                                Sentence = "That's all. <END>",
                                NextLayer = -1
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Hrmpf, I had to lock up Gabe, he turned insane.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "But wait, he found a fix for my code issue.",
                                NextLayer = 2
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Are you sure? Last time I've *tried* to talk to him he almost attacked me. Now he is locked up in his room and I don't know what to do..",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Maybe I can talk to him.",
                                NextLayer = 3
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Hm.. I'm not sure. I need to think, can you bring me a tea?",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Yeah sure, here is one.",
                                NextLayer = 4,
                                IsSelectable = () =>
                                {
                                    return Player.Instance.Inventory.Contains("tea");
                                },
                                ApplyResults = () =>
                                {
                                    Player.Instance.Inventory.Remove("tea");
                                    Player.Instance.Inventory.Add(office_key);
                                }
                            },
                            new DialogOption
                            {
                                Sentence = "Where do I get a tea?",
                                NextLayer = 5
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Ahh nice. Okay, here you go. The key to the office.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Thanks <END>",
                                NextLayer = -1
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "I don't know. Talk to Chefkoch.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Okay <END>",
                                NextLayer = -1
                            }
                        }
                    }
                }
            );
            Creature fly = new Creature("Fly", "A small and annoying animal. Flies around all day just to.. to.. What do flies actually do except for upsetting people?", 1, 20, 16, -15);
            Character chefkoch = new Character("Chefkoch", "The best cook you could imagine, he serves food for you and all of your colleagues. You sometimes wonder how this broad and sturdy person fits into the white cooking apron.", new DialogLayer[]
                {
                    new DialogLayer
                    {
                        Opening = "What's up?",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Smelling delicious in here, what's for lunch?",
                                NextLayer = 1
                            },
                            new DialogOption
                            {
                                Sentence = "Hey, could you make me a tea?",
                                NextLayer = 2
                            },
                            new DialogOption
                            {
                                Sentence = "That's all. <END>",
                                NextLayer = -1
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Today's clubsandwich. Marinated and grilled chicken on levain bread with bacon, ramson mayonnaise, roman lettuce, tomatoes and onion. And french fries.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Damn, your're the best cook ever!",
                                NextLayer = 0
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "I'm actually pretty busy right now. And this annoying fly keeps me distracted from work. I don't know, maybe if you kill it? And bring some water, too!",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Hm.. Okay.",
                                NextLayer = 0
                            },
                            new DialogOption
                            {
                                Sentence = "I killed the fly! Here's some water.",
                                NextLayer = 3,
                                IsSelectable = () =>
                                {
                                    return Player.Instance.Inventory.Contains("water") && !fly.IsAlive;
                                },
                                ApplyResults = () =>
                                {
                                    
                                    Player.Instance.Inventory.Remove("water");
                                    Player.Instance.Inventory.Add(tea);
                                }
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Perfect, here's the tea!",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Wow, that was fast. Thanks! <END>",
                                NextLayer = -1
                            }
                        }
                    }
                }
            );
            Character rat = new Character("Rat", "A small gray rat. Why doesn't it run off?", new DialogLayer[]
                {
                    new DialogLayer
                    {
                        Opening = "Hello?",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "A talking rat. I'm out. <END>",
                                NextLayer = -1
                            },
                            new DialogOption
                            {
                                Sentence = "You can talk?",
                                NextLayer = 1
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Of course. Why would you think that I can't talk?",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Because you're a rat. Animals don't speak.",
                                NextLayer = 2
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "A-ha so I'm not allowed to speak, because I'm a rat? Oppression!",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Man, is there some hallucinogen in the air here?",
                                NextLayer = 3
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "No! Blourgh, I can't stand you.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Me neither, bye. <END>",
                                NextLayer = -1,
                            },
                            new DialogOption
                            {
                                Sentence = "Well, I don't care, I have to find Gabe.",
                                NextLayer = 4
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Be careful, he probably will attack you, as soon as you enter his office.",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "Well, thanks.. I guess. <END>",
                                NextLayer = -1
                            }
                        }
                    }
                }
            );
            Creature gabe_newell = new Creature("Gabe Newell", "Your colleague, but you actually can't recognize him. His eyes turned red and his skin pale. What happened to him?", 20, 12, 6, 2, 2, true);
            Character janitor = new Character("Janitor", "The janitor cleaning the floor.", new DialogLayer[]
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
                                Sentence = "I could help you, I have a broom!",
                                NextLayer = 4,
                                IsSelectable = () =>
                                {
                                    return Player.Instance.Inventory.Contains("broom");
                                }
                            },
                            new DialogOption
                            {
                                Sentence = "Get your shit together, everyone's having problems. <END>",
                                NextLayer = -1
                            }
                        }
                    },
                    new DialogLayer
                    {
                        Opening = "Oh that's nice. Thanks!",
                        DialogOptions = new DialogOption[]
                        {
                            new DialogOption
                            {
                                Sentence = "No worries! <END>",
                                NextLayer = -1
                            }
                        }
                    }
                }
            );

            // Rooms
            Room your_office = new Room("Your office", "A musty smell of sweat and hard mental work is in the air. Your office is rather dark, only lit by a small window and the fluorescent monitor on your desk. You've worked for here for endless hours now.");
            your_office.Items.AddRange(new Item[] {computer, desk, flyswatter});
            
            Room hallway = new Room("Hallway", "The hallway is lit through two massive industry lights on the ceiling, that flood the room in clean, cold light. The floor is glossy, probably the janitor wiped it a few moments ago. With every step you mess up the drying floor.");
            hallway.Items.AddRange(new Item[] {umbrella, jacket, broom});
            hallway.Creatures.AddRange(new Creature[] {janitor});

            Room conference_room = new Room("Conference room", "The air in the conference room is exceptionally fresh. The air refresher must do a pretty good job in here. There is a large glass front on the east side of the room, filling the room with bright daylight. In the center of the room there is a big, round table.");
            conference_room.Items.AddRange(new Item[] {building_plan, coffee});
            conference_room.Creatures.AddRange(new Creature[] {todd_howard, ashley_cheng, craig_lafferty});

            Room lounge = new Room("Lounge", "This room is for relaxing and eating lunch. A large couch with a coffee table in front of it takes up the most of the space in here. There is also a tv hanging on the wall, but it's turned off at the moment.");
            lounge.Items.AddRange(new Item[] {magazine, water});
            lounge.Creatures.AddRange(new Creature[] {phil_spencer});

            Room kitchen = new Room("Kitchen", "From far you could smell the delicious aroma of the lunch the Chefkoch is currently prepares. The whole room is covered in a cloud of steam.");
            kitchen.Items.AddRange(new Item[] {knife});
            kitchen.Creatures.AddRange(new Creature[] {chefkoch, fly});

            Room ventilation_shaft = new Room("Ventilation shaft", "It's dark, dusty and narrow in here. You can barely see where to go. Only through some distant venting slots there's some light coming in.");
            ventilation_shaft.Creatures.AddRange(new Creature[] {rat});

            Room colleagues_office = new Room("Colleague's office", "As in your office, here's a musty smell of sweat and hard mental work. It seems that this room wasn't ventilated or cleaned for a long time now. There's a desk with a computer in the middle of the room. Except that there's not really much in here.");
            colleagues_office.Items.AddRange(new Item[] {mighty_saviour});
            colleagues_office.Creatures.AddRange(new Creature[] {gabe_newell});

            // Room connections
            your_office.Connections.Add("east", new Door("Door to Hallway", "A solid wooden door.", hallway));

            hallway.Connections.Add("west", new Door("Door to your office", "A solid wooden door.", your_office));
            hallway.Connections.Add("east", new Door("Glass door to the conference room", "A large full-frame glass door.", conference_room));
            hallway.Connections.Add("south", new Door("Corridor to the lounge", "This corridor leads to the lounge.", lounge));

            conference_room.Connections.Add("west", new Door("Glass door to the hallway", "A large full-frame glass door.", hallway));

            lounge.Connections.Add("north", new Door("Corridor to the hallway", "This corridor leads to the hallway.", hallway));
            lounge.Connections.Add("west", new Door("Door to the kitchen", "A solid door with a metal panel, you can slide to the right side.", kitchen));
            lounge.Connections.Add("south", new Door("Door to your colleague's office", "A solid wooden door.", colleagues_office, office_key, "As you tried to open this door, you realize that it is locked."));

            kitchen.Connections.Add("east", new Door("Door to the lounge", "A solid door with a metal panel, you can slide to the left side.", lounge));
            kitchen.Connections.Add("south", new Door("Ventilation shaft", "Not far from the ceiling there's a ventilation slot. You may be able to take off the panel and climb up.", ventilation_shaft, building_plan, "You may not enter the ventilation shaft without a map guiding you. Rumors say that even the mightiest facility managers lost track in the branched corridors and never got to see the light of day again."));

            ventilation_shaft.Connections.Add("north", new Door("Ventilation shaft exit", "You can climb down the north corridor of the ventilation shaft.", kitchen));
            ventilation_shaft.Connections.Add("east", new Door("Ventilation shaft exit", "You can climb down the east corridor of the ventilation shaft.", colleagues_office));

            colleagues_office.Connections.Add("north", new Door("Door to the lounge", "A solid wooden door.", lounge, office_key, "As you tried to open this door, you realize that it is locked."));
            colleagues_office.Connections.Add("west", new Door("Ventilation shaft", "Not far from the ceiling there's a ventilation slot. You may be able to take off the panel and climb up.", ventilation_shaft, building_plan, "You may not enter the ventilation shaft without a map guiding you. Rumors say that even the mightiest facility managers lost track in the branched corridors and never got to see the light of day again."));

            return your_office;
        }
    }
}