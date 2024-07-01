using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Ship
{
    public class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        private const int _secondsInTick = 3;
        private bool _isPaused = false;
        
        public CrewController CrewControl { get; set; }
        public RoomManager RoomControl {  get; set; }
        public int TicksTotal { get; private set; } = 0;

        public MainModel()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(_secondsInTick);
            timer.Tick += timerTick;
            timer.Start();

            CrewControl = new CrewController();
            RoomControl = new RoomManager();
            RoomControl.InitializeRooms();
            CrewControl.SpreadCrewOverShip();
        }

        void timerTick(object sender, EventArgs e)
        {

            if (_isPaused)
                return;

            TicksTotal++;

            if (TicksTotal % 5 == 0)
                CrewControl.CrewHungersRandomly();

            CrewControl.CrewVisitsKambuzIfNeeded();
            CrewControl.CrewStraysRandomly();

        }

        

    }

}
