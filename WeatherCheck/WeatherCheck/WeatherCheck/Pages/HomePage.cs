using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherCheck.Models;
using WeatherCheck.ViewModel;
using Xamarin.Forms;
using Forecast = WeatherCheck.ViewModel.Forecast;

namespace WeatherCheck.Pages
{
    public class HomePage : ContentPage
    {
        public ObservableCollection<WeatherListViewModel> ListData { get; set; }

        public HomePage()
        {
            Title = "Weather Check";
            var goButton = new Button
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Text = "Go"
            };

            var cityEntry = new Entry
            {
                Placeholder = "enter your city",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,

            };

            goButton.Clicked += async (sender, args) =>
            {
                IsBusy = true;
                ListData.Add(await GetWeatherData(cityEntry.Text));
                IsBusy = false;
            };

          
            var searchBarLayout = new StackLayout
            {
                Spacing = 12,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(5, 0, 5, 0),
                Children =
                {
                    cityEntry,
                    goButton,
                   
                }
            };

            var temperatureList = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(WeatherDetailCell)),
                ItemsSource = ListData = new ObservableCollection<WeatherListViewModel>(),
                SeparatorColor = Color.FromHex("#77d065"),
                SeparatorVisibility = SeparatorVisibility.Default
            };

            temperatureList.ItemSelected += temperatureList_ItemSelected;


            Content = new StackLayout
            {
                Padding = new Thickness(5, 5, 5, 5),
                Children = { searchBarLayout, temperatureList }
            };
        }

        void temperatureList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var weatherDetailPage = new WeatherDetailPage();
            weatherDetailPage.BindingContext = e.SelectedItem;
            Navigation.PushAsync(weatherDetailPage);
        }

        private async Task<WeatherListViewModel> GetWeatherData(string cityName)
        {
            var httpClient = new HttpClient();
            var responseString = await httpClient.GetStringAsync(string.Format(
                "https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text='{0}') and u='c'&format=json",
                cityName));

            return await Task.Run(() =>
            {
                var dataModel = JsonConvert.DeserializeObject<YahooWeather>(responseString);
                if (dataModel == null)
                    return null;
                var viewModel = new WeatherListViewModel
                {
                    Code = dataModel.Query.Results.Channel.Item.Condition.Code,
                    WeatherDate = dataModel.Query.Results.Channel.Item.Condition.Date,
                    Temparature = string.Format("{0}\u02DA {1}", dataModel.Query.Results.Channel.Item.Condition.Temp, dataModel.Query.Results.Channel.Units.Temperature),
                    WeatherCondition = dataModel.Query.Results.Channel.Item.Condition.Text,
                    ImageSource = new UriImageSource { Uri = new Uri(string.Format("http://l.yimg.com/a/i/us/we/52/{0}.gif", dataModel.Query.Results.Channel.Item.Condition.Code)) },
                    CityAndCountry = string.Format("{0}, {1}", dataModel.Query.Results.Channel.Location.City, dataModel.Query.Results.Channel.Location.Country),
                    Sunrise = string.Format("Sunrise: {0}", dataModel.Query.Results.Channel.Astronomy.Sunrise),
                    Sunset = string.Format("Sunset: {0}", dataModel.Query.Results.Channel.Astronomy.Sunset),
                    Humidity = string.Format("Humidity: {0}\u02DA{1}", dataModel.Query.Results.Channel.Atmosphere.Humidity, dataModel.Query.Results.Channel.Units.Temperature),
                    Pressure = string.Format("Pressure: {0}{1}", dataModel.Query.Results.Channel.Atmosphere.Pressure, dataModel.Query.Results.Channel.Units.Pressure),
                    Visibility = string.Format("Visibility: {0}", dataModel.Query.Results.Channel.Atmosphere.Visibility),
                    Chill = string.Format("Chill: {0}\u02DA{1}", dataModel.Query.Results.Channel.Wind.Chill, dataModel.Query.Results.Channel.Units.Temperature),
                    Direction = string.Format("Direction: {0}", dataModel.Query.Results.Channel.Wind.Direction),
                    Speed = string.Format("Speed: {0}{1}", dataModel.Query.Results.Channel.Wind.Speed, dataModel.Query.Results.Channel.Units.Speed),
                    Forecasts = new List<Forecast>()
                };
                foreach (var forecast in dataModel.Query.Results.Channel.Item.Forecast)
                {
                        viewModel.Forecasts.Add(new WeatherCheck.ViewModel.Forecast()
                        {
                            Day = forecast.Day,
                            ImageSource = new UriImageSource { Uri = new Uri(string.Format("http://l.yimg.com/a/i/us/we/52/{0}.gif", forecast.Code)) },
                            Condition =  forecast.Text,
                            High = forecast.High + " ",
                            Low = forecast.Low,
                            
                        });
                }

                return viewModel;
            });

        }
    }
}

