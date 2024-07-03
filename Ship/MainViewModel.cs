using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Ship.ShipParts;

namespace Ship
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {

        };

        private MainModel _model;
        
        public MainViewModel()
        {
            _model = new MainModel();

            AddRandomCrewerCommand = new DelegateCommand(() =>
            {
                _model.CrewControl.AddRandomCrewer();
            });
            RemoveCrewerCommand = new DelegateCommand<CrewMember>(crewer =>
            {
                _model.CrewControl.RemoveCrewer(crewer, _model.RoomControl.Rooms);
                //_model.StatusManager.OnPropertyChanged();
                CurrentCrewers.Remove(crewer);
            });
            StatusCrewerCommand = new DelegateCommand<CrewMember>(crewer =>
            {
                _model.StatusManager.UpdateStatusedCrewer(crewer);
            });
            RedactCrewerCommand = new DelegateCommand<CrewMember>(crewer =>
            {
                _model.CrewControl.RedactCrewer(crewer);
            });

            GalleyStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusGalley();
            });
            ChestStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusChest();
            });
            ShipStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusShip();
            });
            MastStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusMast();
            });
            CabinStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusCabin();
            });
            DeckStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusDeck();
            });
            CrowsNestStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusCorwsNest();
            });
            TreasureRoomStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusTreasureRoom();
            });
            StockStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusStock();
            });
            SlaveRoomStatus = new DelegateCommand(() =>
            {
                _model.StatusManager.StatusSlaveRoom();
            });

        }

        public DelegateCommand AddRandomCrewerCommand { get; }
        public DelegateCommand<CrewMember> RemoveCrewerCommand { get; }
        public DelegateCommand<CrewMember> StatusCrewerCommand { get; }
        public DelegateCommand<CrewMember> RedactCrewerCommand { get; }
        public DelegateCommand GalleyStatus { get; }
        public DelegateCommand ChestStatus { get; }
        public DelegateCommand ShipStatus { get; }
        public DelegateCommand MastStatus { get; }
        public DelegateCommand CabinStatus { get; }
        public DelegateCommand DeckStatus { get; }
        public DelegateCommand CrowsNestStatus { get; }
        public DelegateCommand TreasureRoomStatus { get; }
        public DelegateCommand StockStatus { get; }
        public DelegateCommand SlaveRoomStatus { get; }

        public ObservableCollection<TreasureRoom> StatusedTreasureRoom => _model.StatusManager.StatusedTreasureRoom;
        public ObservableCollection<ShipClass> WholeShipStatus => _model.StatusManager.WholeShipStatus;
        public ObservableCollection<CrewMember> CurrentCrewers => _model.StatusManager.CurrentShipPartCrewers;
        public ObservableCollection<CrewMember> StatusedCrewer => _model.StatusManager.CurrentStatusedCrewer;
        public ObservableCollection<Stock> StatusedStock => _model.StatusManager.CurrentStatusedStock;
    }

    //This comment is supposed to represent my attitude towards me NOT thinking that the fact that I didn't manage to handle new
    //paradime of programming along with the MVVM technology in two weeks has to be the result of me sitting on second of JULY and
    //writing another SIX HUNDERED lines of code and Databinding MY ASS to that funny-quircky XAML file which is btw bound with MainVIEWMODEL 
    //which is btw bound to MainMODEL which is btw bound to ship which we have to stucture via the fucking DIAGRAMM with those funny
    //arrows and stuff. Have a nice day.


}
