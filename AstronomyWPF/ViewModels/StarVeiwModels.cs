using AstronomyDP;
using AstronomyWPF.Models;
using AstronomyWPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AstronomyWPF.ViewModels
{
    public class StarVeiwModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Star> Stars { get; set; }
        public AddCommand AddStar { get; set; }



        private StarModel CurrentModel;

        public string Famely
        { 
            get { return CurrentModel.Famely; }
            set {
                CurrentModel.Famely = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Famely"));
                }
            }

        }
        public StarVeiwModels()
        {
            CurrentModel = new StarModel();
            Stars = new ObservableCollection<Star>(CurrentModel.Stars);
            Stars.CollectionChanged += Stars_CollectionChanged;
            AddStar = new AddCommand();
            AddStar.Add += AddStar_Add;
        }

        private void Stars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                CurrentModel.Stars.Add(e.NewItems[0] as Star);
            }
        }

        private void AddStar_Add(Star NewStar)
        {
            //Stars.Add(new Star { Name = "weather", ObjectUri = @"https://ssl.gstatic.com/onebox/weather/64/partly_cloudy.png" });
            //MessageBox.Show(CurrentModel.Stars.Count.ToString());
            Stars.Add(NewStar);
        }


    }
}
