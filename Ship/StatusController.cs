using Ship.ShipParts;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ship
{
    public class StatusController : INotifyPropertyChanged
    {
        private ObservableCollection<TreasureRoom> _statusedTreasureRoom;
        private ObservableCollection<Stock> _currentStatusedStock;
        private ObservableCollection<ShipClass> _wholeShipStatus;
        private ObservableCollection<CrewMember> _currentShipPartCrewers;
        private ObservableCollection<CrewMember> _currentStatusedCrewer;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        public StatusController()
        {
            _currentShipPartCrewers = new ObservableCollection<CrewMember>();
            _currentStatusedStock = new ObservableCollection<Stock>();
            _wholeShipStatus = new ObservableCollection<ShipClass>();
            _statusedTreasureRoom = new ObservableCollection<TreasureRoom>();
        }

        public ObservableCollection<ShipPart> ShipParts;
        public ObservableCollection<CrewMember> CurrentStatusedCrewer
        {
            get => _currentStatusedCrewer; set
            {
                if (value.Count > 0)
                    UpdateStatusedCrewer(value[0]);
                else
                    _currentStatusedCrewer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_currentShipPartCrewers)));
            }
        }
       
        public ObservableCollection<CrewMember> CurrentShipPartCrewers
        {
            get => _currentShipPartCrewers;
            set
            {
                UpdateCrewers(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_currentShipPartCrewers)));
            }
        }

        public ObservableCollection<CrewMember> GetCurrentShipPartCrewers(ShipPart shipPart)
        {
            return shipPart.Crewers;
        }

        public void OnPropertyChanged(ShipClass ship, Stock stock, TreasureRoom treasureRoom)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentStatusedCrewer)));
            UpdateWholeShipStatus(ship);
            UpdateStatusedStock(stock);
            UpdateStatusedTreasureRoom(treasureRoom);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WholeShipStatus)));
        }

        public void UpdateStatusedCrewer(CrewMember crewer)
        {
            CurrentStatusedCrewer?.Clear();
            CurrentStatusedCrewer?.Add(crewer);
        }

        public void UpdateWholeShipStatus(ShipClass ship)
        {
            WholeShipStatus?.Clear();
            WholeShipStatus?.Add(ship);
        }

        public void UpdateStatusedStock(Stock stock)
        {
            CurrentStatusedStock?.Clear();
            CurrentStatusedStock?.Add(stock);
        }

        public void UpdateStatusedTreasureRoom(TreasureRoom treasureRoom)
        {
            StatusedTreasureRoom?.Clear();
            StatusedTreasureRoom?.Add(treasureRoom);
        }

        public void StatusShip()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(Ship))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusDeck()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(Deck))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusCabin()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(Cabin))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusChest()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(ChestClass))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusCorwsNest()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(CrowsNest))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusGalley()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(Galley))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusMast()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(Mast))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusSlaveRoom()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(SlaveRoomClass))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusStock()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(Stock))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }
        public void StatusTreasureRoom()
        {
            foreach (ShipPart part in ShipParts)
                if (part.GetType().ToString().Substring(part.GetType().ToString().LastIndexOf('.') + 1) == nameof(TreasureRoom))
                {
                    CurrentShipPartCrewers = part.Crewers;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentShipPartCrewers)));
                    return;
                }
        }

        public void UpdateCrewers(ObservableCollection<CrewMember> newCollection)
        {
            _currentShipPartCrewers.Clear();
            for (int i = 0; i < newCollection.Count; i++) 
            {
                _currentShipPartCrewers.Add(newCollection[i]);
            }
        }

        public ObservableCollection<ShipClass> WholeShipStatus
        {
            get => _wholeShipStatus; set
            {
                if (value.Count > 0)
                    UpdateWholeShipStatus(value[0]);
                else
                    _wholeShipStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_wholeShipStatus)));
            }
        }

        public ObservableCollection<Stock> CurrentStatusedStock
        {
            get => _currentStatusedStock; set
            {
                if (value.Count > 0)
                    UpdateStatusedStock(value[0]);
                else
                    _currentStatusedStock = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_wholeShipStatus)));
            }
        }

        public ObservableCollection<TreasureRoom> StatusedTreasureRoom
        {
            get => _statusedTreasureRoom; set
            {
                if (value.Count > 0)
                    UpdateStatusedTreasureRoom(value[0]);
                else
                    _statusedTreasureRoom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_statusedTreasureRoom)));
            }
        }

    }
}
