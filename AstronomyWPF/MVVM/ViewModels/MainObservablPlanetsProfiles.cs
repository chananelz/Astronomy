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
        public PlanetsProfilesCommands MarsCommand { get; set; }
        public PlanetsProfilesCommands JupiterCommand { get; set; }
        public PlanetsProfilesCommands SaturnCommand { get; set; }
        public PlanetsProfilesCommands UranusCommand { get; set; }
        public PlanetsProfilesCommands NeptuneCommand { get; set; }
        public PlanetsProfilesCommands EarthCommand { get; set; }


        public MercuryViewModel MercuryVM { get; set; }
        public VenusViewModel VenusVM { get; set; }
        public MarsViewModel MarsVM { get; set; }
        public JupiterViewModel JupiterVM { get; set; }
        public SaturnViewModel SaturnVM { get; set; }
        public UranusViewModel UranusVM { get; set; }
        public NeptuneViewModel NeptuneVM { get; set; }
        public EarthViewModel EarthVM { get; set; }


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
            MarsVM = new MarsViewModel();
            JupiterVM = new JupiterViewModel();
            SaturnVM = new SaturnViewModel();
            UranusVM = new UranusViewModel();
            NeptuneVM = new NeptuneViewModel();
            EarthVM = new EarthViewModel();

            CurrentView = EarthVM;

            MercuryCommand = new PlanetsProfilesCommands(o => 
            { 
                CurrentView = MercuryVM;

            });

            VenusCommand = new PlanetsProfilesCommands(o =>
            {
                CurrentView = VenusVM;
            });

            MarsCommand = new PlanetsProfilesCommands(o =>
            {
                CurrentView = MarsVM;

            });

            JupiterCommand = new PlanetsProfilesCommands(o =>
            {
                CurrentView = JupiterVM;
            });

            SaturnCommand = new PlanetsProfilesCommands(o =>
            {
                CurrentView = SaturnVM;

            });

            UranusCommand = new PlanetsProfilesCommands(o =>
            {
                CurrentView = UranusVM;
            });

            NeptuneCommand = new PlanetsProfilesCommands(o =>
            {
                CurrentView = NeptuneVM;

            });

            EarthCommand = new PlanetsProfilesCommands(o =>
            {
                CurrentView = EarthVM;
            });


        }
    }
}
