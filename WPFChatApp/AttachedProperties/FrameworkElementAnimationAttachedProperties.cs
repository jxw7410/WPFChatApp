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
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // get the framework element
            if(!(sender is FrameworkElement element))
                return;
            // Don't fire if value doesn't change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;
            
            if (FirstLoad)//Event will always fire hooking first before unhooking.
            {
                // Create a single self-unhookable event for the elements loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    //Unhooking
                    element.Loaded -= onLoaded; 
                    //animate
                    DoAnimation(element, (bool)value);
                    //This condition only fires once
                    FirstLoad = false; 
                };
                element.Loaded += onLoaded; //Hooking
            }
            else
            {
                DoAnimation(element, (bool)value);
            }
        }

        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
    }


    /// <summary>
    /// Animates a framework element sliding it in from the left on Show
    /// And sliding out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            //Animate In
            if (value)           
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin : false);  
            //Animate out
            else
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin : false);
        }
    }

}
