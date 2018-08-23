namespace WPFChatApp.Core
{
    public class ApplicationViewModel : ViewModelBase
    {
        #region Private Members
        private ApplicationPage currentPage = ApplicationPage.MainChat;
        private bool sideMenuVisible = true;

        #endregion

        #region Public Properties
        public ApplicationPage CurrentPage
        {
            get
            {
                return currentPage;
            }
            private set
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

        /// <summary>
        /// Navigate to desired page
        /// </summary>
        /// <param name="page"></param>
        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
            if (page == ApplicationPage.MainChat)
                SideMenuVisible = true;
        }
        #endregion
    }
}
