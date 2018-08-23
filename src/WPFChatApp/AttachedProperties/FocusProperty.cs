using System.Windows;
using System.Windows.Controls;

namespace WPFChatApp
{
    public class FocusProperty : BaseAttachedProperties<FocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;

            control.Loaded += (s, se) => control.Focus();

        }
    }
}
