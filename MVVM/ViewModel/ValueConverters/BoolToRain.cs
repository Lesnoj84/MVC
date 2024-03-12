using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVM_WeatherApp.ViewModel.ValueConverters
{
    public class BoolToRain : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining = (bool)value;

            if (isRaining)
            {
                return "Raining";
            }
            return "Not Raining";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isRaining = (string)value;

            if(isRaining == "Raining")
            {
                return true;
            } return false;
        }
    }
}
