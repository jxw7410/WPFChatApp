using System.Windows;

namespace WPFChatApp
{
    /// <summary>
    /// Abstract base class to run any animation method, when a boolean is set to true
    /// And a reverse animation is set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperties<Parent, bool>
        where Parent : BaseAttachedProperties<Parent, bool>, new()
    {
        // Flag to indicate whether this is the first time this property has been loaded
        public bool FirstLoad { get; set; } = true;
        public override void OnGenericValueUpdated(DependencyObject sender, object value)
        {
            // get the framework element
            if(!(sender is FrameworkElement element))
                return;
            // Don't fire if value doesn't change
            if (sender.GetValue(GenericProperty) == value)
                return;
            // 
            if (FirstLoad)
            {
                // Create a single self-unhookable event for the elements loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {

                };

                element.Loaded += onLoaded;
            }
        }
    }

}
