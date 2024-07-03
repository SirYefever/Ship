using Ship.ShipParts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;

namespace Ship
{
    public class MainModel : INotifyPropertyChanged
    {
        private StatusController _statusManager;
        private ShipPartsManager _roomControl;
        private CrewController _crewControl;
        private int _cannonsQuantity;
        private int _chestCapacity;
        private int _stockCapacity;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        private bool _isPaused = false;
        private const int _secondsInTick = 1;

        public StatusController StatusManager
        {
            get => _statusManager;
            set
            {
                _statusManager = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_statusManager)));
            }
        }
        public ShipPartsManager RoomControl
        {
            get => _roomControl;
            set
            {
                _roomControl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_roomControl)));
            }
        }
        public CrewController CrewControl
        {
            get => _crewControl;
            set
            {
                _crewControl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_crewControl)));
            }
        }
        public int TicksTotal { get; private set; } = 0;
        public bool IsShipBurning
        {
            get
            {
                foreach (var room in RoomControl.Rooms)
                {
                    if (room.IsBurning)
                        return true;
                }
                return false;
            }
        }

        public MainModel()
        {
            //TODO: Remove
            _cannonsQuantity = 10;
            _stockCapacity = 10;
            _chestCapacity = 10;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(_secondsInTick);
            timer.Tick += timerTick;
            timer.Start();

            StatusManager = new StatusController();
            RoomControl = new ShipPartsManager(_cannonsQuantity, _chestCapacity, _stockCapacity);
            CrewControl = new CrewController();
            StatusManager.ShipParts = RoomControl.Rooms;
            StatusManager.CurrentStatusedCrewer = new ObservableCollection<CrewMember>();
            CrewControl.MainControl = this;
            CrewControl.GenerateCrew();
        }

        public void timerTick(object sender, EventArgs e)
        {

            if (_isPaused)
                return;

            TicksTotal++;

            if (TicksTotal % 5 == 0)
                CrewControl.CrewHungersRandomly();


            RoomControl.ManageBurning();
            CrewControl.ManageExtinguishing();
            RoomControl.ManageExtinguishing();

            CrewControl.CrewVisitsKambuzIfNeeded();
            CrewControl.CrewStraysRandomly();
            CrewControl.ManageBusyness(RoomControl.Rooms);

            StatusManager.OnPropertyChanged(_roomControl.Ship, _roomControl.Ship.deck.stock, _roomControl.Ship.deck.treasureRoom);
        }
    }
}
