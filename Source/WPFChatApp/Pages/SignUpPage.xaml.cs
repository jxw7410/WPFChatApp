using System.Security;

namespace WPFChatApp
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SignUpPage : BasePage<SignUpViewModel>, IHavePassword
    {
        public SignUpPage()
        {
            InitializeComponent();

        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
