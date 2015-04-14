using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherCheck.ViewModel
{
    public class WeatherListViewModel
    {
        public string Code { get; set; }
        public string Temparature { get; set; }
        
        public string CityAndCountry { get; set; }

        public string WeatherDate { get; set; }

        public string WeatherCondition { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set; }

        public string Humidity { get; set; }

        public string Pressure { get; set; }

        public string Visibility { get; set; }

        public string Chill { get; set; }

        public string Direction { get; set; }

        public string Speed { get; set; }


        public UriImageSource ImageSource { get; set; }

        public List<Forecast> Forecasts { get; set; }
    }

    public class Forecast
    {
        public string Day { get; set; }
        public string Code { get; set; }
        public UriImageSource ImageSource { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Condition { get; set; }


    }
}
