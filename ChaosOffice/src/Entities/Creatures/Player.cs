using System;
using System.Collections.Generic;
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

        public int CurrentDialogLayerIndex;

        private Player() : base("Player", "", 20, 12, 4, 0, 2, false, ConsoleColor.Yellow)
        {
            CurrentDialogLayerIndex = 0;
        }

        public void GoTo(string direction)
        {
            if (CurrentRoom.Connections.TryGetValue(direction, out Door door))
            {
                if (door.Key == null || Inventory.Contains(door.Key.Name))
                {
                    EnterRoom(door.NextRoom);
                }
                else
                {
                    Game.WriteLine(door.LockedMessage);
                }
            }
            else
            {
                Say("There is no exit in this direction.");
            }
        }

        public override void EnterRoom(Room room)
        {
            CurrentRoom = room;
            CurrentRoom.PrintRoomIntroduction();
            if (CurrentRoom.TryGetAggressiveCreature(out Creature aggressor))
            {
                aggressor.Print("Just as you entered the room, ", " is attacking you!");
                EngageFight(aggressor);
            }
            else
            {
                CurrentRoom.ExamineRoom();
            }
        }

        public void Attack(string targetName)
        {
            if (targetName == "")
            {
                Say("What should I attack again?");
            }
            else if (CurrentRoom.Creatures.TryGet(targetName, out Creature creature))
            {
                if (creature.IsAlive)
                {
                    EngageFight(creature);
                }
                else
                {
                    Say("This one's already dead.");
                }
            }
            else
            {
                Say("I can't find that.");
            }
        }

        public void EngageFight(Creature creature)
        {
            CurrentTarget = creature;
            creature.CurrentTarget = this;
            Game.Instance.GameState = GameStates.Fight;
            CurrentTarget.Print("You are now fighting: ");
        }

        public void LookAt(string targetName = "")
        {
            if (targetName == "")
            {
                CurrentRoom.ExamineRoom();
            }
            else
            {
                if (CurrentRoom.GetAllEntities().TryGet(targetName, out Entity entity))
                {
                    Game.WriteLine(entity.Description);
                }
                else if (CurrentRoom.Connections.TryGetValue(targetName, out Door door))
                {
                    Game.WriteLine(door.Description);
                }
                else if (Inventory.TryGet(targetName, out Item item))
                {
                    Game.WriteLine(item.Description);
                }
                else
                {
                    Say("I can't see that anywhere.");
                }
            }
        }

        public void PrintInventory()
        {
            if (Inventory.Count != 0)
            {
                Game.WriteLine("In your pockets you find:");
                foreach(Item item in Inventory)
                {
                    item.Print("- ");
                }
            }
            else
            {
                Say("I have nothing with me.");
            }
        }

        public void SpeakTo(string characterName)
        {
            if (CurrentRoom.Creatures.TryGet(characterName, out Creature creature))
            {
                if (creature.IsAlive)
                {
                    Character character = creature as Character;
                    if (character != null)
                    {
                        if (character.Dialog != null)
                        {
                            Game.Instance.GameState = GameStates.Dialog;
                            CurrentTarget = character;
                            character.CurrentTarget = this;
                            CurrentDialogLayerIndex = 0;
                            character.Say(CurrentDialogLayerIndex);
                        }
                        else
                        {
                            Say("I think this person won't talk to me.");
                        }
                    }
                    else
                    {
                        Say("I probably won't get an answer from that.");
                    }
                }
                else
                {
                    Say("I can't talk to the dead.");
                }
            }
            else
            {
                Say("Can't find that character here.");
            }
        }

        public void PickDialogLine(string line)
        {
            if (int.TryParse(line, out int lineIndex))
            {
                Character character = CurrentTarget as Character;
                List<DialogOption> dialogOptions = character.Dialog[CurrentDialogLayerIndex].GetAvailableDialogOptions();
                if (lineIndex > 0 && lineIndex <= dialogOptions.Count)
                {
                    DialogOption dialogOption = dialogOptions[lineIndex - 1];
                    Say(dialogOption.Sentence);
                    dialogOption.ApplyResults();
                    CurrentDialogLayerIndex = dialogOption.NextLayer;
                    if(CurrentDialogLayerIndex == -1)
                    {
                        Game.Instance.GameState = GameStates.Adventure;
                        character.CurrentTarget = null;
                        CurrentTarget = null;
                    }
                    else
                    {
                        character.Say(CurrentDialogLayerIndex);
                    }
                }
                else
                {
                    Game.WriteLine("Please select a number that is actually there.");
                }
            }
            else
            {
                Game.WriteLine("Please select a number.");
            }
        }

        public void TakeItem(string itemName)
        {
            if (itemName == "")
            {
                Say("What am I looking for again?");
            }
            else if (CurrentRoom.Items.TryGet(itemName, out Item item))
            {
                if (item.Takeable)
                {
                    CurrentRoom.Items.Remove(item);
                    Inventory.Add(item);
                    item.Print("You took ", ".");
                }
                else
                {
                    Say("Ouuuhaarrrg. I cannot put that in my pockets, it's too heavy.");
                }
            }
            else
            {
                Say("Damn, i can't find that anywhere.");
            }
        }

        public void DropItem(string itemName)
        {
            if (itemName == "")
            {
                Say("What did i want to drop again?");
            }
            else if (Inventory.TryGet(itemName, out Item item))
            {
                Inventory.Remove(item);
                CurrentRoom.Items.Add(item);
                item.Print("You dropped ", ".");
            }
            else
            {
                Say("Damn, i can't find that in my pockets.");
            }
        }

        public void ConsumeItem(string itemName)
        {
            if (itemName == "")
            {
                Say("What did I want to consume again?");
            }
            else if (Inventory.Contains(itemName))
            {
                ConsumeableItem item = Inventory.Get(itemName) as ConsumeableItem;
                if (item != null)
                {
                    if (Health != MaxHealth)
                    {
                        RestoreHealth(item.HealthRegeneration);
                        item.Print("You consumed ", ".");
                        Inventory.Remove(item);
                        if (Game.Instance.GameState == GameStates.Fight)
                        {
                            Game.Instance.FinishFightingRound();
                        }
                    }
                    else
                    {
                        Say("I'm feeling pretty good, I think consuming that now would be a waste.");
                    }
                }
                else
                {
                    Say("I'd rather not consume that.");
                }
            }
            else
            {
                Say("Damn, i can't find that in my pockets.");
            }
        }

        public void BeatTarget(string weaponName)
        {
            if (weaponName == "")
            {
                BeatTarget();
                Game.Instance.FinishFightingRound();
            }
            else if (Inventory.TryGet(weaponName, out Item item))
            {
                Weapon weapon = item as Weapon;
                if (weapon != null)
                {
                    BeatTarget(weapon.DamageDice, weapon.DamageModifier, weapon.Accuracy);
                    Game.Instance.FinishFightingRound();
                }
                else
                {
                    Say("I don't think it is a good idea to use that as a weapon.");
                }
            }
            else
            {
                Say("Damn, I can't find that in my pockets..");
            }
        }
    }
}