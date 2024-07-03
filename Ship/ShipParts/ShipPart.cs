using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ship
{
    public abstract class ShipPart : INotifyPropertyChanged
    {
        private ObservableCollection<CrewMember> _crewers;
        private bool _isBurning;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        public bool IsBurning
        {
            get => _isBurning;
            set
            {
                _isBurning = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBurning)));
            }
        }

        public ObservableCollection<CrewMember> Crewers { get => _crewers;
            set
            {
                _crewers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Crewers)));
            } }

        public ShipPart()
        {
            Crewers = new ObservableCollection<CrewMember>();
            IsBurning = false;
        }
    }
}
