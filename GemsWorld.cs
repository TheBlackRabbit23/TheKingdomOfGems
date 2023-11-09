using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class GemsWorld
    {
        private static GemsWorld _instance = null;
        public static GemsWorld Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GemsWorld();
                }
                return _instance;
            }
        }

        private Room _entrance;
        public Room Entrance { get { return _entrance; } }

        private Room _exit;
        public Room Exit { get { return _exit; } }


        private GemsWorld()
        {
            _entrance = CreateWorld();


            NotificationCenter.Instance.AddObserver("PlayerEnteredRoom", PlayerEnteredRoom);
            NotificationCenter.Instance.AddObserver("PlayerWillLeaveRoom", PlayerWillLeaveRoom);


        }

        //new code
        public void PlayerWillLeaveRoom(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player != null)
            {
                player.WarningMessage("The player is " + player.CurrentRoom.Tag);
            }
        }
        //

        //new code
        public void PlayerEnteredRoom(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player != null)
            {

                player.InfoMessage("You are " + player.CurrentRoom.Tag);
            }
        }
        

        public Room CreateWorld()
        {
            Room gemsKingdom = new Room("inside the enclosure of the Gems Kingdom.");
            Room celestialPalace = new Room("inside the walls of the Celestial Palace.");
            Room aquamarineLake = new Room("in the Aquamarine Lake, ran by aquatic beings.");
            Room plumParadise = new Room("in Plum Paradise, where the gems plum fairies reside.");
            Room jasperGate = new Room("in Jasper Gate, where the gems dragons are inhabiting. ");
            Room crystalRock = new Room("in Crystal Rock, where you all search for the Sapphire box and key.)");
            Room etherealCave = new Room("in the Ethereal Cave, where you all search for the Ruby box and key.");
            Room pearlCastle = new Room("in the Pearl Castle, where you all search for the Diamond box and key.");
            Room jewelsCountry = new Room("you all walk to Jewels Country where you meet a wise old lady who gives you all a map, a compass, and clues.");
            Room jadeForest = new Room("in the Jade Forest, where you all search for the Emerald box and key.");
            Room zirconPortal = new Room("in the Zircon Portal, the portal to return back to earth");

            //connect the Gems Kingdom, the Aquamarine Lake, and the Celestial Palace
            Door door = Door.ConnectRooms("west", "east", gemsKingdom, aquamarineLake);
            Door.ConnectRooms("closet", "east", gemsKingdom, celestialPalace);
            
            //connect outside the Aquamarine Lake, the Jasper Gate, the Pearl Castle, and the Plum Paradise
            Door.ConnectRooms("north", "south", aquamarineLake, jasperGate);
            Door.ConnectRooms("west", "east", aquamarineLake, pearlCastle);
            Door.ConnectRooms("south", "north", aquamarineLake, plumParadise);
            Item item = new Item("Bucket of aquafina", 2.0f);
            aquamarineLake.DropItem(item);

            //connect the Plum Paradise and the Crystal Rock
            Door.ConnectRooms("west", "east", plumParadise, crystalRock);

            //connect the Crystal Rock and the Pearl Castle
            Door.ConnectRooms("north", "south", crystalRock, pearlCastle);

            //connect the Pearl Castle and the Ethereal Cave
            Door.ConnectRooms("north", "south", pearlCastle, etherealCave);

            //connect the Ethereal Cave and the Plum Paradise
            Door.ConnectRooms("east", "west", etherealCave, plumParadise);
            Item item1 = new Item("Bag of gems", 2.0f);
            plumParadise.DropItem(item1);

            //connect the Plum Paradise, the Jewels Country, and the Jade Forest
            Door.ConnectRooms("east", "west", plumParadise, jewelsCountry);
            Door.ConnectRooms("north", "south", plumParadise, jadeForest);
            Item item2 = new Item("Compass", 2.0f);
            jewelsCountry.DropItem(item2);
            Item item3 = new Item("Map", 1.0f);
            jewelsCountry.DropItem(item3);

            //connect the Jade Forest and the Zircon Portal
            Door.ConnectRooms("north", "south", jadeForest, zirconPortal);




            //The implementation of the TRAP ROOM
            TrapRoom tr = new TrapRoom("Kabloom");
            jasperGate.Delegate = tr;
            tr.ContainingRoom = jasperGate;


            ItemContainer box1 = new ItemContainer("Diamond Box");
            ItemContainer box2 = new ItemContainer("Ruby Box");
            ItemContainer box3 = new ItemContainer("Emerald Box");
            ItemContainer box4 = new ItemContainer("Sapphire Box");
            item = new Item("Diamond key", 4.0f);
            box1.Insert(item);
            item = new Item("Ruby key", 4.0f);
            box2.Insert(item);
            item = new Item("Emerald key", 4.0f);
            box3.Insert(item);
            item = new Item("Sapphire key", 4.0f);
            box4.Insert(item);

            pearlCastle.DropItem(box1);
            etherealCave.DropItem(box2);
            jadeForest.DropItem(box3);
            crystalRock.DropItem(box4);

            return zirconPortal;

        }
    }
}








