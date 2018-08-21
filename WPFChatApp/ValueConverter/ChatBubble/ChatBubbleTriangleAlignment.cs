using System;
using System.Globalization;
using System.Windows;


namespace WPFChatApp
{
    public class ChatBubbleTriangeAlignment : BaseValueConverter<ChatBubbleTriangeAlignment>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == false)
                return HorizontalAlignment.Right;
            else
                return HorizontalAlignment.Left;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
