using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

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
                    crewMember.Move(MainControl.RoomControl.GetRoom("Galley"));
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

                        //Get busy until extinguished
                        crewMember.BusyUntil = int.MaxValue;
                    }
                }
                //Exempt crewMember from extinguishing if job is done
                if (crewMember.IsBusy && !crewMember.CurrentRoom.IsBurning)
                    crewMember.BusyUntil = 0;
                
            }
        }

        public void ManageBusiness()
        {
            foreach (var crewMember in Crew)
            {
                if (crewMember.BusyUntil <= MainControl.TicksTotal)
                    crewMember.IsBusy = true;
                else
                    crewMember.IsBusy = false;
            }
        }

        public void AddRandomCrewer()
        {
            List<string> Names = new List<string>() { "Blackbeard", "Henry Morgan", "William Kidd", "Black Bart", "Black Fart", "Calico", "Drake", "Every", "Bony", "Mary Read", "Grace O'Malley" };
            var rand = _rnd.Next(Names.Count);//include or exclude
            string name = Names[rand];
            string sex;
            if (name == "Bony" || name == "Mary Read" || name == "Grace O'Malley")
                _crew.Add(new CrewMember(Names[rand], "female"));
            else
                _crew.Add(new CrewMember(Names[rand], "male"));
        }

        public void RemoveCrewer(CrewMember crewer)
        {
            _crew.Remove(crewer);
        }

        public void StatusCrewer(CrewMember crewer)
        {
            throw new NotImplementedException();
        }

        public void RedactCrewer(CrewMember crewer)
        {
            throw new NotImplementedException();
        }
    }
}
