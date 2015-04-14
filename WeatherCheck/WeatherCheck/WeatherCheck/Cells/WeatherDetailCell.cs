using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherCheck
{
    public class WeatherDetailCell : ViewCell
    {
        public WeatherDetailCell()
        {
           
            var temparatureLabel = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                ,
                TextColor = Color.FromHex("#3498db")
            };
            temparatureLabel.SetBinding(Label.TextProperty, "Temparature");

            var cityCountryLabel = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
            };
            cityCountryLabel.SetBinding(Label.TextProperty, "CityAndCountry");

            var timeLabel = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };
            timeLabel.SetBinding(Label.TextProperty, "WeatherDate");

            var temparatureLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Children = { temparatureLabel, cityCountryLabel, timeLabel}
            };

            var weatherImage = new Image()
            {
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 25,
                HeightRequest = 25
            };
            weatherImage.SetBinding(Image.SourceProperty, "ImageSource");

            var conditionLabel = new Label
            {
                HorizontalOptions = LayoutOptions.End,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = Color.FromHex("#b455b6")
            };
            conditionLabel.SetBinding(Label.TextProperty, "WeatherCondition");

            var conditionLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.End,
                Orientation = StackOrientation.Vertical,
                Children = { weatherImage, conditionLabel}
                
            };

            var cellLayout = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(10, 5, 10, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {temparatureLayout, conditionLayout }
            };
            
            this.View = cellLayout;
        }
    }
}
