namespace WPFChatApp.Core
{
    public class ApplicationViewModel : ViewModelBase
    {
        private ApplicationPage currentPage = ApplicationPage.Login;
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
        private bool sideMenuVisible = false;
        
    }
}
