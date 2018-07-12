
namespace WPFChatApp.Core
{
    public class ApplicationViewModel : ViewModelBase
    {
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

        private ApplicationPage currentPage = ApplicationPage.Login;
        
    }
}
