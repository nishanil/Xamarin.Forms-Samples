using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherCheck.ViewModel;
using Xamarin.Forms;

namespace WeatherCheck.Pages
{
    public partial class WeatherDetailPage : ContentPage
    {
        public WeatherListViewModel ViewModel {
            get { return BindingContext as WeatherListViewModel; }
            set { BindingContext = value; }
        }
        
        public WeatherDetailPage()
        {
            InitializeComponent();

           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var speachString = string.Format("Weather in {0} is {1}. Hope you are enjoying a good day!", ViewModel.CityAndCountry, ViewModel.Temparature);
            ToolbarItems.Add(new ToolbarItem(
                "Speak",
                null,
                () => DependencyService.Get<ITextToSpeech>().Speak(speachString),
                ToolbarItemOrder.Primary,
                0));
        }
    }
}
