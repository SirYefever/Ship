using System;
using System.Collections.ObjectModel;

namespace Ship
{
    public class RoomManager
    {
        private ObservableCollection<Room> _rooms;
        private Random _rnd;

        public ObservableCollection<Room> Rooms { get => _rooms; }
        public int RoomsQuantity { get => _rooms.Count; }
        public Room GetRoom(string name)
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
            Rooms.Add(new Room("Каюта"));
            Rooms.Add(new Room("Палуба"));
            Rooms.Add(new Room("Мачта"));
            Rooms.Add(new Room("Камбуз"));
            Rooms.Add(new Room("Воронье Гнездо"));
            Rooms.Add(new Room("Сокровищница"));
            Rooms.Add(new Room("Склад"));
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
            foreach(var room in Rooms)
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
