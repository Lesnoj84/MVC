using MVVM_WeatherApp.Model;
using MVVM_WeatherApp.ViewModel.Commands;
using MVVM_WeatherApp.ViewModel.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MVVM_WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        public SearchCommand SearchCommand { get; set; }
        public ObservableCollection<City> Cities { get; set; }


        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnprepertyChanged();
            }
        }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnprepertyChanged();
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnprepertyChanged();
                
                if(SelectedCity.Key != null)
                MoreInfoAboutWeather();
               
            }
        }

        

        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                SelectedCity = new City { LocalizedName = "Prague" };
                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Cloudy",
                    Temperature = new Temperature { Metric = new Units { Value = "21" } }
                };
            }
            SearchCommand = new SearchCommand(this);
            
            Cities = new ObservableCollection<City>();

        }

        private async void MoreInfoAboutWeather()
        {
            Cities.Clear();
            Query = string.Empty;
                                  
            if(CurrentConditions!=null)
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);

        }


        
        public async void MakeQuery()
        {
            var cityList = await AccuWeatherHelper.GetCities(Query);
            Cities.Clear();

            foreach (City city in cityList)
            {
                Cities.Add(city);
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnprepertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

    }
}
