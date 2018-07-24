
using System.Windows;
using System.Windows.Controls;

namespace WPFChatApp
{
    //Refer to ReadMe1.txt for a more specific approach
    public class MonitorPasswordProperty : BaseAttachedProperties<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = (sender as PasswordBox);

            if (passwordBox == null)
                return;

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged; //clean previous event

            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValue(passwordBox, passwordBox.SecurePassword.Length > 0);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }


    }
    public class HasTextProperty : BaseAttachedProperties<HasTextProperty, bool> 
    {
    }
}
