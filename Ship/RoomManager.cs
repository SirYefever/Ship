using Ship.ShipParts;
using System;
using System.Collections.ObjectModel;

namespace Ship
{
    public class RoomManager
    {
        private ObservableCollection<ShipPart> _rooms;
        private Random _rnd;

        public ShipClass Ship { get; set; }
        public ChestClass Chest { get; set; }
        public SlaveRoomClass SlaveRoom { get; set; }
        public ObservableCollection<ShipPart> Rooms { get => _rooms; }
        public int RoomsQuantity { get => _rooms.Count; }
        public ShipPart GetRoom(string roomType)
        {
            foreach (var room in _rooms)
            {
                if (room.GetType().ToString() == roomType)
                    return room;
            }
            Console.WriteLine("Room " + roomType + " not found.");
            return null;
        }

        public RoomManager()
        {
            Ship = new ShipClass(5);
            Chest = new ChestClass();
            SlaveRoom = new SlaveRoomClass();
            Ship.deck.treasureRoom.chest = Chest;
            Ship.deck.treasureRoom.slaveRoom = SlaveRoom;
        }

        public void InitializeRooms()
        {
        }

        public void ManageBurning()
        {
            if (!GetRoom(nameof(Galley)).IsBurning)
            {
                double rand = _rnd.NextDouble();
                if (rand <= 0.3)
                {
                    GetRoom(nameof(Galley)).IsBurning = true;
                }
            }
            foreach (var room in Rooms)
            {
                if (room.IsBurning)
                {
                    double rand = _rnd.NextDouble();
                    if (rand <= 0.45)
                    {
                        foreach (var room2 in Rooms)
                        {
                            if (!room2.IsBurning)
                            {
                                room2.IsBurning = true;
                                return;
                            }
                        }
                    }
                }
            }
        }
        public void ManageExtinguishing()
        {
            foreach (var room in Rooms)
            {
                if (room.IsBurning)
                {
                    double extinguishPossibility = 1 - (100 / room.Crewers.Count);
                    if (_rnd.NextDouble() < extinguishPossibility)
                        room.IsBurning = false;
                }
            }
        }
    }
}
