using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Door : ILockable
    {
        private Room _room1;
        private Room _room2;
        private bool _open;
        private ILockable _lock;
        public ILockable TheLock { set { _lock = value; } get { return _lock; } }
        public bool IsOpen { get { return _open; } }
        public bool IsClosed { get { return !_open; } }
        public bool IsLocked { get { return _lock == null ? false : _lock.IsLocked; } }
        public bool IsUnlocked { get { return _lock == null ? true : _lock.IsUnlocked; } }

        public Door(Room room1, Room room2)
        {
            _lock = null;
            _open = true;
            _room1 = room1;
            _room2 = room2;
        }

        public Room RoomOnTheOtherSideOf(Room fromHere)
        {
            return fromHere != _room1 ? _room1 : _room2;
        }
        public bool Open()
        {
            _open = _lock == null ? true : _lock.OnOpen();
            return _open;
        }
        public bool Close()
        {
            _open = _lock == null ? false : !_lock.OnClose();
            return _open;
        }
        public bool OnOpen()
        {
            return _lock == null ? true : _lock.OnOpen();

        }
        public bool OnClose()
        {
            return _lock == null ? true : _lock.OnClose();
        }
        public bool Lock()
        {
            if (_lock != null)
            {
                _lock.Lock();
                return true;
            }
            return false;
        }
        public bool Unlock()
        {
            if (_lock != null)
            {
                _lock.Unlock();
                return true;
            }
            return false;
        }
        public static Door ConnectRooms(String label1, String label2, Room room1, Room room2)
        {
            Door door = new Door(room1, room2);
            room1.SetExit(label1, door);
            room2.SetExit(label2, door);
            return door;
        }
    }
}

