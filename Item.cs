using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Item : IItem
    {
        private String _name;
        public string Name { get { return _name; } }


        private float _weight;
        public float Weight { get { return _weight + (_decorator == null ? 0 : _decorator.Weight); } }//if dec is eqaul to 0 nothing, else add weight to it

        private IItem _decorator;
        public Item() : this("NAMELESS") { }

        public Item(string name) : this(name, 1f) { }

        //designated constructor 
        public Item(String name, float weight)
        {
            _name = name;
            _weight = weight;
            _decorator = null;
        }

        //adds a decorator 
        public void AddDecorator(IItem decorator)
        {
            if (_decorator == null) //if there is nothing in decorator
            {
                _decorator = decorator;
            }
            else //if decorator has something
            {
                _decorator.AddDecorator(decorator);
            }
        }
        public bool IsContainer { get { return false; } }

        public String Description
        {
            get
            {
                return LongName + " - " + Weight;
            }
        }
        public String LongName { get { return Name + (_decorator == null ? "" : ", " + _decorator.LongName); } }
    }


    public class ItemContainer : Item, IItemContainer
    {

        public ItemContainer() : base() { }
        public ItemContainer(String name) : base(name) { }
        public ItemContainer(string name, float weight) : base(name, weight) { }

        private Dictionary<string, IItem> _items = new Dictionary<string, IItem>();

        public void Insert(IItem item)
        {
            _items[item.Name] = item;
        }
        public void Purchase(IItem item)
        {
            _items[item.Name] = item;
        }
        public IItem Remove(String itemName)
        {
            IItem item = null;
            _items.TryGetValue(itemName, out item);
            _items.Remove(itemName);
            return item;
        }

        public new bool IsContainer { get { return true; } }

        public new String Description
        {
            get
            {
                String output = "";
                foreach (IItem item in _items.Values)
                {
                    output += item.Description + "\n";
                }
                return base.Description + "\nContents\n" + output;
            }
        }
    }
}








