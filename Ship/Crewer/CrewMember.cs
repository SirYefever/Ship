using System;
using System.ComponentModel;

namespace Ship
{
    public class CrewMember : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        private string _name;
        private string _sex;
        private bool _isHngry;
        private Random _rnd = new Random();

        public CrewMember(string name, string sex)
        {
            _name = name;
            _sex = sex;
            _isHngry = false;
        }

        public string Hungriness
        {
            get
            {
                if (_isHngry)
                    return "Голодный";
                else
                    return "Сытый";
            }
        }

        public string Busyness
        {
            get
            {
                if (IsBusy)
                    return BusyUntil == int.MaxValue ? "ТУШИТ" : "Хавает";
                else
                    return "Свободен";
            }
        }

        public string CurrentRoomString
        {
            get
            {
                return CurrentRoom.GetType().ToString().Substring(CurrentRoom.GetType().ToString().LastIndexOf('.') + 1);
            }
        }

        public ShipPart CurrentRoom { get; set; }
        public string Name
        {
            get => _name; set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        public string Sex
        {
            get => _sex; set
            {
                _sex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sex)));
            }
        }

        public int BusyUntil { get; set; }

        public bool IsHungry
        {
            get => _isHngry; set
            {
                _isHngry = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsHungry)));
            }
        }

        public bool IsBusy { get; set; }

        public void Move(ShipPart room)
        {
            if (!(CurrentRoom == null))
                CurrentRoom.Crewers.Remove(this);
            room?.Crewers.Add(this);
            CurrentRoom = room;
        }

        public void HungerRandomly()
        {
            double rand = _rnd.NextDouble();
            if (rand < 0.3)
            {
                _isHngry = true;
            }
        }

        public void Eat()
        {
            _isHngry = false;
        }
    }
}
