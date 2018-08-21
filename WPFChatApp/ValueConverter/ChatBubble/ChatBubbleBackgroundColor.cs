using System;
using System.Globalization;
using System.Windows.Media;

namespace WPFChatApp
{
    public class ChatBubbleBackgroundColor : BaseValueConverter<ChatBubbleBackgroundColor>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("Azure"));
            else
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("White"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
