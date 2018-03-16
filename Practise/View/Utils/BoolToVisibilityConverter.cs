using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LeetCodePractise.View.Utils
{
    /// <summary>
    /// The converter between bool(true/false) to visiblity(visible/collapse)
    /// </summary>
    /// Created by:jzeng
    /// On: 10/10/2016
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the visibility value if true.
        /// </summary>
        /// <value>
        /// The visiblility if true.
        /// </value>
        public Visibility VisibilityIfTrue { get; set; } = Visibility.Visible;

        /// <summary>
        /// Gets or sets the visibility value if false.
        /// </summary>
        /// <value>
        /// The visiblility if false.
        /// </value>
        public Visibility VisibilityIfFalse { get; set; } = Visibility.Collapsed;
        
        /// <summary>
        /// Converts a bool value to Visibility value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// Visible when true, Collapsed when false or null value.
        /// </returns>
        /// Created by:jzeng
        /// On: 10/10/2016
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = VisibilityIfFalse;
            if (value == null || !(value is bool))
            {
                return result;
            }
            if ((bool)value)
            {
                result = VisibilityIfTrue;
            }
            return result;
        }

        /// <summary>
        /// Converts a visiblity value to bool value back.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// Created by:jzeng
        /// On: 10/13/2016
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = true;
            if ((value == null) || !(value is Visibility))
            {
                return result;
            }
            if ((Visibility)value == VisibilityIfFalse)
            {
                result = false;
            }
            return result;
        }
    }
}
