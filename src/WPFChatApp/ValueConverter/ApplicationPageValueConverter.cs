using System;
using System.Diagnostics;
using System.Globalization;
using WPFChatApp.Core;
namespace WPFChatApp
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login: //whenever viewmodel changes page
                    return new LoginPage();  //creates a new instance of a login page everytime we go to a login page  
                case ApplicationPage.Error:
                    return new ErrorPage();
                case ApplicationPage.MainChat:
                    return new ChatPage();
                case ApplicationPage.SignUp:
                    return new SignUpPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}