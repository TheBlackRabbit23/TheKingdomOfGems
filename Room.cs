using System.Collections;
using System.Collections.Generic;
using System;

namespace $safeprojectname$
{
    /*
     * Spring 2023
     */
    public class Room
    {
        private Dictionary<string, Door> _exits;
        private string _tag;
        private IRoomDelegate _delegate;
        public IRoomDelegate Delegate { set { _delegate = value; } get { return _delegate; } }

        public string Tag { get { return _delegate == null ? _tag : _delegate.OnTag; } set { _tag = value; } }

        //item for inventory
        private IItemContainer _items;

        public Room() : this("No Tag") { }

        // Designated Constructor
        public Room(string tag)
        {
            _delegate = null;
            _exits = new Dictionary<string, Door>();
            this.Tag = tag;
            _items = new ItemContainer("Floor", 0f);
        }

        public void SetExit(string exitName, Door door)
        {
            _exits[exitName] = door;
        }

        public Door GetExit(string exitName)
        {
            Door door = null;
            _exits.TryGetValue(exitName, out door);
            return _delegate == null ? door : _delegate.OnGetExit(exitName);
        }

        public string GetExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Door>.KeyCollection keys = _exits.Keys;
            foreach (string exitName in keys)
            {
                exitNames += " " + exitName;
            }

            return _delegate == null ? exitNames : _delegate.OnGetExits(exitNames);
        }

        public void DropItem(IItem item)
        {
            _items.Insert(item);
        }
        public void BuyItem(IItem item)
        {
            _items.Insert(item);
        }

        public IItem PickUpItem(String name)

        {
            IItem item = _items.Remove(name);
            return item;
        }



        public string Description()
        {
            return "You are " + this.Tag + ".\n *** " + this.GetExits() + "\n" + _items.Description;
        }

    }
    public class TrapRoom : IRoomDelegate
    {
        private bool _active;
        private String _password { get; set; }
        private Room _containingRoom { get; set; }
        public Room ContainingRoom
        {
            set
            {
                _containingRoom = value;
            }
            get
            {
                return _containingRoom;
            }
        }

        //des constructor
        public TrapRoom(String password)
        {
            _active = true;
            _password = password;
            NotificationCenter.Instance.AddObserver("PlayerDidSayAWord", OnPlayerDidSayAWord);
        }

        public String OnTag { get { return "in a TRAP ROOM"; } }

        public Door OnGetExit(string exitName)
        {
            return null;
        }
        public String OnGetExits(String fromRoom)
        {
            return _active ? "MUAHAHAHAHA \n" : "" + fromRoom;
        }
        public void OnPlayerDidSayAWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player != null)
            {
                if (player.CurrentRoom.Delegate == this)
                {
                    Dictionary<string, object> userInfo = notification.UserInfo;
                    var word = (string)userInfo["word"];
                    if (word == _password)
                    {
                        _active = false;
                        player.CurrentRoom.Delegate = null;
                        NotificationCenter.Instance.RemoveObserver("PlayerDidSayAWord", OnPlayerDidSayAWord);
                        player.InfoMessage("The trap has been disabled");
                    }
                    else
                    {
                        player.ErrorMessage("The password is not correct");
                    }
                }
            }
        }
    }
}
