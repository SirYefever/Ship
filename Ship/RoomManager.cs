using Ship.ShipParts;
using System;
using System.Collections.ObjectModel;

namespace Ship
{
    public class RoomManager
    {
        private ObservableCollection<ShipPart> _rooms;
        private Random _rnd;

        public ObservableCollection<ShipPart> Rooms { get => _rooms; }
        public int RoomsQuantity { get => _rooms.Count; }
        public ShipPart GetRoom(string name)
        {
            foreach (var room in _rooms)
            {
                if (room.Name == name)
                    return room;
            }
            Console.WriteLine("Room " + name + " not found.");
            return null;
        }

        public void InitializeRooms()
        {
            Rooms.Add(new ShipPart("Каюта"));
            Rooms.Add(new ShipPart("Палуба"));
            Rooms.Add(new ShipPart("Мачта"));
            Rooms.Add(new ShipPart("Камбуз"));
            Rooms.Add(new ShipPart("Воронье Гнездо"));
            Rooms.Add(new ShipPart("Сокровищница"));
            Rooms.Add(new ShipPart("Склад"));
        }

        public void ManageBurning()
        {
            if (!GetRoom("Камбуз").IsBurning)
            {
                double rand = _rnd.NextDouble();
                if (rand <= 0.3)
                {
                    GetRoom("Камбуз").IsBurning = true;
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
