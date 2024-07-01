using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private bool _isBusy = false;
        private Random _rnd = new Random();
        public Room CurrentRoom { get; set; }

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

        public bool IsBusy
        {
            get => _isBusy; set
            {
                _isHngry = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        public void Move(Room room)
        {
            CurrentRoom.Crewers.Remove(this);
            room.Crewers.Add(this);
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
