using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LeetCodePractise.View.Utils
{
    /// <summary>
    /// The converter for comparing whether binded integer are equaled to the integer as parameter
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class IntComparisonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value == (int)parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
