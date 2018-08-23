using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFChatApp.Core;

namespace WPFChatApp
{
    /// <summary>
    /// base page for all pages
    /// </summary>
    public class BasePage : UserControl
    {
        #region public properties:
        //enter
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRightAsync;
        //exit
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToRightAsync;

        //used for dependecy PageHost to know whether frame should animate out (instead of recreating it self and animate in)
        public bool IsAnimateOut { get; set; } 

        //Duration of animation 
        public float SlideSeconds { get; set; } = 0.3f;
     
        #endregion

        public BasePage()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
            //monitoring for page loading
            this.Loaded += BasePage_LoadedAsync;
        }

        #region Animation Load/Unload
        protected async void BasePage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            if (IsAnimateOut)
                await AnimateOutAsync();
            else
                await AnimateInAsync();
        }

        public async Task AnimateInAsync()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;
            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRightAsync:
                    await this.SlideAndFadeInFromRightAsync(this.SlideSeconds, width: (int)Application.Current.MainWindow.Width);
                    break;
            }
        }


        public async Task AnimateOutAsync()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;
            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToRightAsync:
                    await this.SlideAndFadeOutToRightAsync(this.SlideSeconds, width: (int)Application.Current.MainWindow.Width);
                    break;
            }

        }

        #endregion
    }

    /// <summary>
    /// BasePage w/ added view models support
    /// </summary>
    public class BasePage<VM> : BasePage
        where VM : ViewModelBase, new()
    {

        #region Private Members
        private VM mViewModel;

        #endregion
        #region public properties

        public VM ViewModel
        {
            get
            {               
                return mViewModel;
            }
            set
            {
                //if nothing changed, return the same thing
                if (mViewModel == value)
                    return;
                //else change to new viewModel( of page)
                mViewModel = value;
                //set the datacontext binding to the new viewmodel
                this.DataContext = mViewModel;
            }
        }
        #endregion

        public BasePage() : base()
        {        
            this.ViewModel = new VM();
        }
       
    }
}
