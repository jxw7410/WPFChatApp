using System;
using System.Globalization;
using System.Windows;


namespace WPFChatApp
{   /// <summary>
    /// Takes a DateTimeOffset and convert it to some user friendly format 
    /// </summary>
    public class ReadTimeReformatConverter : BaseValueConverter<ReadTimeReformatConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            //if it is not read...
            if (time.Date == DateTime.MinValue)
                return string.Empty;

            //If it is still today, return just time
            if (time.Date == DateTimeOffset.UtcNow.Date)
                return "Read: " + time.ToLocalTime().ToString("hh:mm");
            //if it is not today
            else
                return "Read: " + time.ToLocalTime().ToString("hh:mm, MMM dd yyyy");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
