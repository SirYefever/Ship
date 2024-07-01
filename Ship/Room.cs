using System.Collections.ObjectModel;
using System.ComponentModel;

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

    }
}
