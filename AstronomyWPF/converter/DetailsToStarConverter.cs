using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AstronomyWPF
{
    internal class DetailsToStarConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Star Result = new Star();
            if ((values != null) && (values.Length > 1))
            {
                Result.Name = values[0].ToString();
                Result.ObjectUri = values[1].ToString();
            }
            

            return Result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;    
        }
    }
}
