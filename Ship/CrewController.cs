using System;
using System.Collections.ObjectModel;

namespace Ship
{
    public class CrewController
    {
        private ObservableCollection<CrewMember> _crew;
        private Random _rnd = new Random();

        public ObservableCollection<CrewMember> Crew { get => _crew; }
        public MainModel MainControl { get; set; }


        public void CrewHungersRandomly()
        {
            foreach (var crewMember in _crew)
            {
                double rand = _rnd.NextDouble();
                if (rand < 0.3)
                {
                    crewMember.IsHungry = true;
                }
            }
        }

        public void CrewVisitsKambuzIfNeeded()
        {
            foreach (var crewMember in _crew)
                if (crewMember.IsHungry && !crewMember.IsBusy)
                {
                    crewMember.Move(MainControl.RoomControl.GetRoom("Камбуз"));
                    crewMember.BusyUntil = MainControl.TicksTotal + 1;
                }
        }

        public void SpreadCrewOverShip()
        {
            foreach(var crewMember in _crew)
            {
                int rand = _rnd.Next(MainControl.RoomControl.RoomsQuantity);
                crewMember.Move(MainControl.RoomControl.Rooms[rand]);
            }
        }

        public void CrewStraysRandomly()
        {
            foreach (var crewMember in _crew)
            {
                if (!crewMember.IsBusy)
                {
                    int rand = _rnd.Next(MainControl.RoomControl.RoomsQuantity);
                    crewMember.Move(MainControl.RoomControl.Rooms[rand]);
                }
            }
        }

        public void ManageExtinguishing()
        {
            foreach( var crewMember in _crew)
            {
                while (!crewMember.IsBusy)
                {
                    int rand = _rnd.Next(MainControl.RoomControl.RoomsQuantity);
                    if (MainControl.RoomControl.Rooms[rand].IsBurning)
                    {
                        crewMember.Move(MainControl.RoomControl.Rooms[rand]);

                        //get busy until extinguished
                        crewMember.BusyUntil = int.MaxValue;
                    }
                }
                if (crewMember.IsBusy && !crewMember.CurrentRoom.IsBurning)
                {
                    crewMember.BusyUntil = 0;
                }
            }
        }
    }
}
