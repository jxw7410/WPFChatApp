using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFChatApp.Core;

namespace WPFChatApp
{
    /// <summary>
    /// BasePage for all pages
    /// </summary>
    public class BasePage<VM> : Page
        where VM : ViewModelBase, new()
    {

        #region Private Members
        private VM mViewModel;

        #endregion
        #region public properties:
        //enter
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRightAsync;
        //exit
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToRightAsync;

        //Duration of animation 
        public float SlideSeconds { get; set; } = 1.5f;

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

        public BasePage()
        {
            //if we are animating in hide
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
            //monitoring for page loading
            this.Loaded += BasePage_LoadedAsync;
            this.ViewModel = new VM();
        }

        #region Animation Load/Unload
        private async void BasePage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await AnimateInAsync();
        }

        public async Task AnimateInAsync()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
            {
                return;
            }
            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRightAsync:
                    await this.SlideAndFadeInFromRightAsync(this.SlideSeconds);
                    break;
            }
        }


        public async Task AnimateOutAsync()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
            {
                return;
            }
           
           switch (this.PageUnloadAnimation)
           {
                case PageAnimation.SlideAndFadeOutToRightAsync:
                    await this.SlideAndFadeOutToRightAsync(this.SlideSeconds);
                    break;
           }
           
        }

        #endregion

    }
}
