using AstronomyWPF.MVVM.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyWPF.MVVM.ViewModels
{
    class MainObservablPlanetsProfiles : ObservablPlanetsProfiles
    {
        public PlanetsProfilesCommands MercuryCommand { get; set; }
        public PlanetsProfilesCommands VenusCommand { get; set; }
        public MercuryViewModel MercuryVM { get; set; }
        public VenusViewModel VenusVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainObservablPlanetsProfiles()
        {
            MercuryVM = new MercuryViewModel();
            VenusVM = new VenusViewModel(); 

            CurrentView = MercuryVM;

            MercuryCommand = new PlanetsProfilesCommands(o => 
            { 
                CurrentView = MercuryVM;

            });

            VenusCommand = new PlanetsProfilesCommands(o =>
            {
                CurrentView = VenusVM;
            });


        }
    }
}
