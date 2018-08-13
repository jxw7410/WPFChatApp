using System;
using System.Windows;

namespace WPFChatApp
{
    public abstract class BaseAttachedProperties<Parent, Property>
        where Parent : new()
    {
        #region Public Events
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };
        #endregion

        #region Public Properties
        /// <summary>
        /// Singleton instance of base class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();
        #endregion

        #region Attached Property Definitions
        /// <summary>
        /// The Callback event wehn the <see cref="GenericProperty"/> is changed
        /// </summary>
        /// <param name="d">UI entity that has requires this attached property changed</param>
        /// <param name="e">The argument for the event</param>
        /// 
        public static readonly DependencyProperty ValueProperty =
             DependencyProperty.RegisterAttached("Value", 
                                                  typeof(Property),
                                                  typeof(BaseAttachedProperties<Parent, Property>),
                                                  new UIPropertyMetadata(default(Property), 
                                                  new PropertyChangedCallback(OnPropertyChanged),
                                                  new CoerceValueCallback(OnPropertyUpdated)
                                                  ));
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //call base function
            (Instance as BaseAttachedProperties<Parent, Property>)?.OnValueChanged(d, e);
            // call event listeners
            (Instance as BaseAttachedProperties<Parent, Property>)?.ValueChanged(d, e);
        }

        /// <summary>
        /// Call back when property is updated even if the property is till the same, i.e true to true
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>

        private static object OnPropertyUpdated(DependencyObject d, object value)
        {
            //call base function
            (Instance as BaseAttachedProperties<Parent, Property>)?.OnValueUpdated(d, value);
            // call event listeners
            (Instance as BaseAttachedProperties<Parent, Property>)?.ValueUpdated(d, value);

            return value;
        }

        /// <summary>
        ///Same:
        ///public static Property GetValue(DependencyObject d)
        ///{
        ///     return (Property) d.GetValue(GenericProperty);
        ///}
        /// </summary>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, Property Value) => d.SetValue(ValueProperty, Value);

        #endregion

        #region Event Methods
        //overload function for specific UI entity that inherits from Base class
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){}

        public virtual void OnValueUpdated(DependencyObject sender, object value) { }
        #endregion
    }
}
