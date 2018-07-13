using System;
using System.Globalization;
using System.Windows.Media;

namespace WPFChatApp
{
    /// <summary>
    /// Converts RGB string to Brush used for MVVM (this won't be implemented, here for reference).
    /// </summary>
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
