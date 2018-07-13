namespace WPFChatApp.Core
{
    public class ApplicationViewModel : ViewModelBase
    {
        #region Private Members
        private ApplicationPage currentPage = ApplicationPage.Login;
        private bool sideMenuVisible = false;

        #endregion

        #region Public Properties
        public ApplicationPage CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                PropertyChangedEvent("CurrentPage");
            }
        }
        public bool SideMenuVisible
        {
            get
            {
                return sideMenuVisible;
            }
            set
            {
                sideMenuVisible = value;
                PropertyChangedEvent("SideMenuVisible");
            }
        }
        #endregion

    }
}
