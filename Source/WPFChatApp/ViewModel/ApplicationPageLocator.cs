using WPFChatApp.Core;

namespace WPFChatApp
{
    public class ApplicationPageLocator
    {
        public static ApplicationPageLocator Instance { get; private set; } = new ApplicationPageLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
