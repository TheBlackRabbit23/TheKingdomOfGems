using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public interface IRoomDelegate
    {
        Room ContainingRoom { set; get; }
        Door OnGetExit(string exitName);
        String OnGetExits(String fromRoom);
        String OnTag { get; }
    }

    public interface ICloseable
    {
        bool IsOpen { get; }
        bool IsClosed { get; }
        bool Open();
        bool Close();
    }

    public interface ILockable : ICloseable
    {
        bool IsLocked { get; }
        bool IsUnlocked { get; }
        bool Lock();
        bool Unlock();
        bool OnOpen();
        bool OnClose();

    }

    public interface IItem
    {
        string Name { get; } //name of item
        float Weight { get; } //weight of item
        String LongName { get; } //description of item

        void AddDecorator(IItem decorator);
        String Description { get; }
        bool IsContainer { get; }
    }

    public interface IItemContainer : IItem
    {
        void Insert(IItem item);
        IItem Remove(String itemName);

    }


}













