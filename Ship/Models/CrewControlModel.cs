using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ship
{
    public class CrewControlModel : INotifyPropertyChanged
    {
        private ObservableCollection<CrewMember> _crew;
        private Random _rnd = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        //public ObservableCollection<CrewMember> Crew { get => _crew; }
        public CrewMember StatusedCrewer { get; set; } = new CrewMember("TEST", "TEST");
        public MainModel MainControl { get; set; }

        public CrewControlModel()
        {
            _crew = new ObservableCollection<CrewMember>();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_crew)));
        }

        public ObservableCollection<CrewMember> GetCrew(ObservableCollection<ShipPart> shipParts)
        {
            _crew.Clear();
            foreach (var shipPart in shipParts)
            {
                foreach (var crewer in shipPart.Crewers)
                    _crew.Add(crewer);
            }
            return _crew;
        }

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
                    crewMember.IsHungry = false;
                    crewMember.BusyUntil = MainControl.TicksTotal + 1;
                }
        }

        public void GenerateCrew()
        {
            for (int i = 0; i < 10; i++)
                AddRandomCrewer();

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
            if (!MainControl.IsShipBurning)
                return;

            foreach( var crewMember in _crew)
            {
                while (!crewMember.IsBusy)
                {
                    int rand = _rnd.Next(MainControl.RoomControl.RoomsQuantity);
                    if (MainControl.RoomControl.Rooms[rand].IsBurning)
                    {
                        crewMember.Move(MainControl.RoomControl.Rooms[rand]);

                        //Get busy until extinguished
                        crewMember.IsBusy = true;
                        crewMember.BusyUntil = int.MaxValue;
                    }
                }
                //Exempt crewMember from extinguishing if job is done
                if (crewMember.IsBusy && !crewMember.CurrentRoom.IsBurning)
                {
                    crewMember.BusyUntil = 0;
                    crewMember.IsBusy = false;
                }
                
            }
        }
        //TODO: Check if busyness gets managed properly
        public void ManageBusyness(ObservableCollection<ShipPart> shipParts)
        {
            foreach (var crewMember in GetCrew(shipParts))
            {
                if (crewMember.BusyUntil >= MainControl.TicksTotal)
                    crewMember.IsBusy = true;
                else
                    crewMember.IsBusy = false;
            }
        }

        public void AddRandomCrewer()
        {
            List<string> Names = new List<string>() { "Черная Борода", "Морган", "Кидд", "Черный Барт", "Черный Фарт", "Калико", "Дрэйк", "Ивери", "Бони", "Мэрри Ред", "Грейс О'Мэлли" };
            var rand = _rnd.Next(Names.Count);
            string name = Names[rand];
            string sex;
            if (name == "Bony" || name == "Mary Read" || name == "Grace O'Malley")
                _crew.Add(new CrewMember(Names[rand], "♀"));
            else
                _crew.Add(new CrewMember(Names[rand], "♂"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_crew)));
        }

        public void RemoveCrewer(CrewMember crewer, ObservableCollection<ShipPart> shipParts)
        {
            foreach (var shipPart in shipParts)
            {
                if (shipPart.Crewers.Contains(crewer))
                {
                    shipPart.Crewers.Remove(crewer);
                    
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(shipPart.Crewers)));
                    break;
                }
            }
        }

        public void RedactCrewer(CrewMember crewer)
        {
            CrewerRedactWindow crewerRedactWindow = new CrewerRedactWindow(crewer);
            crewerRedactWindow.Show();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(crewer)));
        }
    }
}
