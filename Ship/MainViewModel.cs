using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
                _model.CrewControl.RemoveCrewer(crewer);
            });
            StatusCrewerCommand = new DelegateCommand<CrewMember>(crewer =>
            {
                _model.CrewControl.StatusCrewer(crewer);
            });
            RedactCrewerCommand = new DelegateCommand<CrewMember>(crewer =>
            {
                _model.CrewControl.RedactCrewer(crewer);
            });
        }

        public DelegateCommand AddRandomCrewerCommand { get; }
        public DelegateCommand<CrewMember> RemoveCrewerCommand { get; }
        public DelegateCommand<CrewMember> StatusCrewerCommand { get; }
        public DelegateCommand<CrewMember> RedactCrewerCommand { get; }

    }
}
