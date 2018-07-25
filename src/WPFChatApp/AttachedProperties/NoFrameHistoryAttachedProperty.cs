using System.Windows;
using System.Windows.Controls;

namespace WPFChatApp
{
    /// <summary>
    /// Keeps navigation (frame UI) history empty
    /// </summary>
    public class NoFrameHistoryAttachedProperty : BaseAttachedProperties<NoFrameHistoryAttachedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);

            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //clear history once navigated
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry(); 
        }
    }
}
