using System;
using System.Globalization;
using System.Windows.Data;


namespace CIS657_Paper.Utilities
{
    public class NullableValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int res;
            bool isInt = int.TryParse(value.ToString(), out res);

            if (isInt)
                return value;
            else
                return null;
        }
    }
}


