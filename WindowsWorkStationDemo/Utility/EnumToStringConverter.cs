using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WindowsWorkStationDemo.Properties;

namespace WindowsWorkStationDemo.Utility
{
    [ValueConversion(typeof(Enum), typeof(string))]
    public class EnumToStringConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            CheckSourceType(typeof(Enum), value);
            CheckTargetType(typeof(string), targetType, true);

            Type valueType = value.GetType();
            FieldInfo fieldInfo = valueType.GetField(value.ToString(), BindingFlags.Static | BindingFlags.Public);

            if (fieldInfo == null)
            {
                throw new ArgumentException(Resources.BitFieldsNotSupported, "value");
            }

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return fieldInfo.Name;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            CheckSourceType(typeof(string), value);
            CheckTargetType(typeof(Enum), targetType, false);

            string str = (string)value;

            foreach (var fieldInfo in targetType.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (fieldInfo.Name == str)
                    return fieldInfo.GetValue(null);

                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                foreach (var attribute in attributes)
                {
                    if (attribute.Description == str)
                    {
                        return fieldInfo.GetValue(null);
                    }
                }
            }

            throw new ArgumentException(string.Format(Resources.EnumValueNotFound, str), "value");
        }
        #endregion

        #region Private Methods
        private static void CheckSourceType(Type supportedSourceType, object value)
        {
            if (!supportedSourceType.IsInstanceOfType(value))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ValueNotOfType, supportedSourceType.Name), "value");
            }
        }

        private static void CheckTargetType(Type supportedTargetType, Type requestedTargetType, bool covariance)
        {
            if (covariance)
            {
                if (!requestedTargetType.IsAssignableFrom(supportedTargetType))
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.TargetNotExtendingType, requestedTargetType.Name, supportedTargetType.Name), "targetType");
                }
            }
            else
            {
                if (!supportedTargetType.IsAssignableFrom(requestedTargetType))
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.TargetNotExtendingType, requestedTargetType.Name, supportedTargetType.Name), "targetType");
                }
            }
        }
        #endregion
    }
}
