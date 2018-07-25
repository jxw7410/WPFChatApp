using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFChatApp
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        /// <summary>
        /// Similiar to attachedProperties
        /// </summary>
        #region  Dependecy Property
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        // Using a DependencyProperty as the backing store for Property CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged)); 
        #endregion

        #region constructor
        public PageHost()
        {
            InitializeComponent();
        }
        #endregion

        #region Property Change Event
        private static void CurrentPagePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var newPageFrame = (sender as PageHost).NewPage;
            var oldPageFrame = (sender as PageHost).OldPage;

            //temp variable to old new which will replace old, after new has been resetted
            var oldPageContent = newPageFrame.Content;
            newPageFrame.Content = null;
            oldPageFrame.Content = oldPageContent;

            //Animiate previous page
            if (oldPageContent is BasePage oldPage)
            {
                oldPage.IsAnimateOut = true;
                Task.Run(oldPage.AnimateOutAsync);//running a task with no await
            }            
            //set the new content 
            newPageFrame.Content = e.NewValue;
        }
        #endregion
    }
}
