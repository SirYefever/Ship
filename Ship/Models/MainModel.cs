using Ship.ShipParts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Ship
{
    public class MainModel : INotifyPropertyChanged
    {
        private StatusControlModel _statusManager;
        private ShipPartControlModel _roomControl;
        private CrewControlModel _crewControl;
        private int _cannonsQuantity;
        private int _chestCapacity;
        private int _stockCapacity;
        private bool _crowsNestRequired;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        private bool _isPaused = false;
        private const int _secondsInTick = 2;

        public StatusControlModel StatusManager
        {
            get => _statusManager;
            set
            {
                _statusManager = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_statusManager)));
            }
        }
        public ShipPartControlModel RoomControl
        {
            get => _roomControl;
            set
            {
                _roomControl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_roomControl)));
            }
        }
        public CrewControlModel CrewControl
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
            _crowsNestRequired = true;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(_secondsInTick);
            timer.Tick += timerTick;
            timer.Start();

            StatusManager = new StatusControlModel();
            RoomControl = new ShipPartControlModel(_cannonsQuantity, _chestCapacity, _stockCapacity, _crowsNestRequired);
            CrewControl = new CrewControlModel();
            StatusManager.ShipParts = RoomControl.Rooms;
            StatusManager.CurrentStatusedCrewer = new ObservableCollection<CrewMember>();
            CrewControl.MainControl = this;
            CrewControl.GenerateCrew();
        }

        public void timerTick(object sender, EventArgs e)
        {
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
