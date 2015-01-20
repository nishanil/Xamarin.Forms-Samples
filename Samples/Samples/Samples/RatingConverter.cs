using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Samples
{
    class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var rating = (int)value;
            if (rating == 1)
                return "Disappointed!";
            if (rating == 2)
                return "Not a fan!";
            if (rating == 3)
                return "It's Ok!";
            if (rating == 4)
                return "Like it!";
            if (rating == 5)
                return "Love it!";

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
