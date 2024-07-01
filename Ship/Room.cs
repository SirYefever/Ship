using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    public class Room : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        public bool IsBurning {  get; set; }

        public Room(string name) 
        {
            Name = name;
        }

        public string Name { get; set; }
        public ObservableCollection<CrewMember> Crewers { get; set; }
        public bool IsBurning {  get; set; }

    }
}
