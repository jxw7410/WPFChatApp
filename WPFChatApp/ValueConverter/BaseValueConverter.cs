using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFChatApp
{
    /// <summary>
    /// Base Value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">Generic Type Class</typeparam>
    /// 
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T:class, new()  //Type is class and newable
    {
        /// <summary>
        /// A single static instance of this converter
        /// </summary>
        private static T mConverter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
           /*
            * Same as if(mConverter==null)
            *           mConverter = new T();
            *         return mConverter;
            */
        }

        #region//IValueConverter functions
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);      
        #endregion
    }
}
