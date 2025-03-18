using Ship.ShipParts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ship
{
    public class ShipPartControlModel : INotifyPropertyChanged
    {
        private ObservableCollection<ShipPart> _rooms;
        private Random _rnd = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        public ShipClass Ship { get; set; }
        public ChestClass Chest { get; set; }
        public SlaveRoomClass SlaveRoom { get; set; }
        public ObservableCollection<ShipPart> Rooms { get => _rooms; }
        public int RoomsQuantity { get => _rooms.Count; }

        public ShipPart GetRoom(string roomType)
        {
            foreach (var room in _rooms)
            {
                string shipPartName = room.GetType().ToString();
                shipPartName = shipPartName.Substring(shipPartName.LastIndexOf('.') + 1);
                if (shipPartName == roomType)
                    return room;
            }
            Console.WriteLine("Room " + roomType + " not found.");
            return null;
        }

        public ShipPartControlModel(int cannonsQuantity, int chestCapacity, int stockCapacity, bool crowsNestRequired)
        {
            Ship = new ShipClass(cannonsQuantity, chestCapacity, stockCapacity, crowsNestRequired);
            Chest = new ChestClass();
            SlaveRoom = new SlaveRoomClass();
            Ship.deck.treasureRoom.chest = Chest;
            Ship.deck.treasureRoom.slaveRoom = SlaveRoom;
            _rooms = new ObservableCollection<ShipPart>();
            InitializeRooms();
        }

        public void InitializeRooms()
        {
            _rooms.Add(Ship);
            _rooms.Add(Ship.deck);
            _rooms.Add(Ship.deck.mast);
            _rooms.Add(Ship.deck.cabin);
            _rooms.Add(Ship.deck.galley);
            _rooms.Add(Ship.deck.stock);
            _rooms.Add(Ship.deck.treasureRoom);
            if (!(Ship.deck.mast.crowsNest == null))
                _rooms.Add(Ship.deck.mast.crowsNest);
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
                    double extinguishPossibility = room.Crewers.Count == 0 ? 0 : 1 - (100 / room.Crewers.Count) / 100.0f;
                    if (_rnd.NextDouble() < extinguishPossibility)
                        room.IsBurning = false;
                }
            }
        }
    }
}
