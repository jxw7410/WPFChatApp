using System;
using System.Diagnostics;
using System.Globalization;
using WPFChatApp.Core;


namespace WPFChatApp
{ 
    public class IocConverter : BaseValueConverter<IocConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel): //whenever viewmodel changes page
                    return IoC.Get<ApplicationViewModel>();  //creates a new instance of a login page everytime we go to a login page  
                    /*
                case ApplicationPage.Error:
                    return new ErrorPage();
                case ApplicationPage.MainChat:
                    return new ChatPage();
                case ApplicationPage.SignUp:
                    return new SignUpPage();
                    */
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
