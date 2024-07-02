using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ship
{
    public class ShipPart : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        public bool IsBurning {  get; set; }

        public ObservableCollection<CrewMember> Crewers { get; set; }
    }
}
