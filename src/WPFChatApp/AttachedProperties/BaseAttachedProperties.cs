using System;
using System.Windows;

namespace WPFChatApp
{
    public abstract class BaseAttachedProperties<GenericType, Property>
        where GenericType : BaseAttachedProperties<GenericType,Property>, new()
    {
        #region Public Events
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> GenericTypeChanged = (sender, e) => { };

        public event Action<DependencyObject, object> GenericValueUpdated = (sender, value) => { };
        #endregion

        #region Public Properties
        /// <summary>
        /// Singleton instance of base class
        /// </summary>
        public static GenericType Instance { get; private set; } = new GenericType();
        #endregion

        #region Attached Property Definitions
        /// <summary>
        /// The Callback event wehn the <see cref="GenericProperty"/> is changed
        /// </summary>
        /// <param name="d">UI entity that has requires this attached property changed</param>
        /// <param name="e">The argument for the event</param>
        /// 
        public static readonly DependencyProperty GenericProperty =
             DependencyProperty.RegisterAttached("Value", 
                                                  typeof(Property),
                                                  typeof(BaseAttachedProperties<GenericType, Property>),
                                                  new UIPropertyMetadata(default(Property), 
                                                  new PropertyChangedCallback(OnGenericPropertyChanged),
                                                  new CoerceValueCallback(OnGenericPropertyUpdated)
                                                  ));
        private static void OnGenericPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //call base function
            Instance.OnGenericTypeChanged(d, e);
            // call event listeners
            Instance.GenericTypeChanged(d, e);
        }

        /// <summary>
        /// Call back when property is updated even if the property is till the same, i.e true to true
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>

        private static object OnGenericPropertyUpdated(DependencyObject d, object value)
        {
            //call base function
            Instance.OnGenericValueUpdated(d, value);
            // call event listeners
            Instance.GenericValueUpdated(d, value);

            return value;
        }

        /// <summary>
        ///Same:
        ///public static Property GetValue(DependencyObject d)
        ///{
        ///     return (Property) d.GetValue(GenericProperty);
        ///}
        /// </summary>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(GenericProperty);

        public static void SetValue(DependencyObject d, Property Value) => d.SetValue(GenericProperty, Value);

        #endregion

        #region Event Methods
        //overload function for specific UI entity that inherits from Base class
        public virtual void OnGenericTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){}

        public virtual void OnGenericValueUpdated(DependencyObject sender, object value) { }
        #endregion
    }
}
