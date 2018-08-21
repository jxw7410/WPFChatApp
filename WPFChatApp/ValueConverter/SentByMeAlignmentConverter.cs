using System;
using System.Globalization;
using System.Windows;


namespace WPFChatApp
{
    public class SentByMeAlignmentConverter : BaseValueConverter<SentByMeAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
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
