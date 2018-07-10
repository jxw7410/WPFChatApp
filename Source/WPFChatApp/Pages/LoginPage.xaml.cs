
using System.Security;

namespace WPFChatApp
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel> , IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
