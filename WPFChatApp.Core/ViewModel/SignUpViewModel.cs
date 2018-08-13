using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFChatApp.Core
{
    /// <summary>
    /// View Model class to describe the customized Window 
    /// </summary>
    public class SignUpViewModel : ViewModelBase
    {

        #region Commands   
        public ICommand SignUpCommand { get; set; }
        public ICommand LoginPageCommand { get; set; }
        #endregion

        #region Constructors
        public SignUpViewModel()
        {          
            SignUpCommand = new RelayParameterizedCommand(async (parameter) => await SignUpAsync(parameter));
            LoginPageCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
        }

        /// <summary>
        /// Attempt to log user in
        /// </summary>
        /// <param name="parameter">SecureString</param>
        /// <returns></returns>
        public async Task SignUpAsync(object parameter)
        {
            #region Basic Approach
            /*
            if (IsLoggingIn)
                return;
            try
            {
                IsLoggingIn = true;
                await Task.Delay(500);
                var email = Email;
                (parameter as IHavePassword).SecurePassword.Unsecure();//pass this entire thing to a webserver to keep security
            }
            catch { }
            finally
            {
                IsLoggingIn = false;
            }
            */
            #endregion

            //Advanced Approach
            await RunCommand(() => this.IsSigningIn, async () =>
             {
                 await Task.Delay(1500);                
                 var email = this.Email;
                 (parameter as IHavePassword).SecurePassword.Unsecure();
                 IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Error);
             });
           
        }

        public async Task LoginAsync(object parameter)
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
            await Task.Delay(1);
        }
        #endregion

        #region Public Members
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.SignUp;

        public string Email {get; set;}
        public bool IsSigningIn
        {
            get
            {
                return SignInFlag;
            }
            set
            {
                SignInFlag = value;
                PropertyChangedEvent("IsSigningIn");
            }
        }//Flagging the Login Button
        #endregion

        private bool SignInFlag;

        public string EmailTag { get; set; } = "Email";
        public string PasswordTag { get; set; } = "Password";

    }
}