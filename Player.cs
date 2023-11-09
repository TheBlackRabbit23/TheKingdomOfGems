using System.Collections;
using System.Collections.Generic;
using System;

namespace $safeprojectname$
{
    /*
     * Spring 2023
     */
    public class Player
    {
        private Room _currentRoom = null;
        public Room CurrentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        private IItemContainer _inventory;


        public Player(Room room)
        {
            _currentRoom = room;
            _inventory = new ItemContainer("Inventory", 0f);
        }
        public void WaltTo(string direction)
        {
            Door door = this.CurrentRoom.GetExit(direction);
            if (door != null)
            {
                //new code
                //Notification notification = new Notification("PlayerWillLeaveRoom", this);
                //NotificationCenter.Instance.PostNotification(notification);
                //
                Room nextRoom = door.RoomOnTheOtherSideOf(CurrentRoom);
                CurrentRoom = nextRoom;
                //new code
                //notification = new Notification("PlayerEntered", this);
                //NotificationCenter.Instance.PostNotification(notification);
                //


                NormalMessage("\n" + this.CurrentRoom.Description());
            }
            else
            {
                ErrorMessage("\nThere is no door on " + direction);
            }
        }

        public void Say(String word)
        {
            Notification notification = new Notification("PlayerWillSayAWord", this);
            Dictionary<string, object> userInfo = new Dictionary<string, object>();
            userInfo["word"] = word;
            notification.UserInfo = userInfo;
            NotificationCenter.Instance.PostNotification(notification);
            NormalMessage(word);
            notification = new Notification("PlayerDidSayAWord", this);
            notification.UserInfo = userInfo;
            NotificationCenter.Instance.PostNotification(notification);
        }
        public void Character() {
            string characterName1, characterName2, characterName3, characterName4;
            string fourGirls;

            Console.WriteLine("Why hello there! I am a wise old lady. What is your name?");
            characterName1 = Console.ReadLine();
            characterName2 = Console.ReadLine();
            characterName3 = Console.ReadLine();
            characterName4 = Console.ReadLine();

            Console.WriteLine("It is an honor to meet you all " + characterName1, characterName2, characterName3, characterName4);
            Console.WriteLine("The wise old lady gives the girls a map, a compass, and clues to find the Zircon Portal. ");
            Console.WriteLine(characterName1, characterName2, characterName3, characterName4 + " thank you for visiting. ");
            Console.WriteLine("1. Gemma");
            Console.WriteLine("2. Amber");
            Console.WriteLine("3. Esmeralda");
            Console.WriteLine("4. Amethyst");
            fourGirls = Console.ReadLine().ToLower();
            switch (fourGirls)
            {
                case "1":
                case "Gemma":
                    {
                        Console.WriteLine("It's an honor to meet you. I will give you the compass.");
                    }
                    break;

                case "2":
                case "Amber":
                    {
                        Console.WriteLine("It's an honor to meet you. I will give you the map.");
                    }
                    break;

                case "3":
                case "Esmeralda":
                    {
                        Console.WriteLine("It's an honor to meet you. I will give you some clues");
                    }
                    break;

                case "4":
                case "Amethyst":
                    {
                        Console.WriteLine("It's an honor to meet you. Let me show you the way to your next location.");
                    }
                    break;



            }
        }
        public void Give()
        {
            Console.WriteLine("Will the aquatic beings give you all aquafina water?");
        }
            public void Read()
        {
            Console.WriteLine("Are you able to read the map?");

        }
        public void Search()
        {
            Console.WriteLine("Search your locations on the map for the four boxes and four keys");
        }
        public void Fight()
        {
            Console.WriteLine("Can you fight the aquatic beings?");
        }
        public void Meet()
        {
            Console.WriteLine("Can you meet with the gems plum faires?");
        }
        //Examine method
        public void Examine(string itemName)
        {
            IItem item = CurrentRoom.PickUpItem(itemName);
            if (item != null)
            {
                InfoMessage(item.Description);
                CurrentRoom.DropItem(item);
            }
            else
            {
                ErrorMessage("there is no item named " + itemName);
            }
        }

        public void Give(IItem item)
        {
            _inventory.Insert(item);
        }

        public IItem Take(String itemName)
        {
            return _inventory.Remove(itemName);
        }

        public void Buy(String itemName)
        {
            IItem item = Take(itemName);
            if (item != null)
            {
                CurrentRoom.BuyItem(item);
                NormalMessage("You have bought the " + itemName);
            }
            else
            {
                ErrorMessage("You didn't bought the item named " + itemName);
            }
    }

        public void PickUp(String itemName)
        {
            IItem item = CurrentRoom.PickUpItem(itemName);
            if (item != null)
            {
                Give(item);
                NormalMessage("You picked up " + itemName);
            }
            else
            {
                ErrorMessage("There is no item named " + itemName + "in the room");
            }
        }

        public void Drop(String itemName)
        {
            IItem item = Take(itemName);
            if (item != null)
            {
                CurrentRoom.DropItem(item);
                NormalMessage("You dropped " + itemName);
            }
            else
            {
                ErrorMessage("You don't have an item named " + itemName);
            }
        }

        public void Extract(String itemName, String containerName)
        {
            IItem item = CurrentRoom.PickUpItem(containerName);
            if (item != null)
            {
                if (item.IsContainer)
                {
                    IItemContainer container = (IItemContainer)item;
                    item = container.Remove(itemName);
                    if (item != null)
                    {
                        Give(item);
                        NormalMessage("You extracted " + itemName + " from " + containerName);
                    }
                    else
                    {
                        ErrorMessage("The item " + itemName + "is not in " + containerName);


                    }
                    CurrentRoom.DropItem(container);
                    CurrentRoom.BuyItem(container);
                }
                else
                {
                    ErrorMessage(containerName + " is not a container");
                }
            }
            else
            {
                ErrorMessage("There is no container named " + containerName);
            }
        }

        public void Inventory()
        {
            NormalMessage(_inventory.Description);
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ColoredMessage(string message, ConsoleColor newColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = newColor;
            OutputMessage(message);
            Console.ForegroundColor = oldColor;
        }

        public void NormalMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.White);
        }

        public void InfoMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.Blue);
        }

        public void WarningMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.DarkYellow);
        }

        public void ErrorMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.Red);
        }
    }

}
