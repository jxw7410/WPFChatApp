using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFChatApp.Core
{
    /// <summary>
    /// View Model class to describe the customized Window 
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {

        #region Commands   
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpPageCommand { get; set; }
        #endregion

        #region Constructors
        public LoginViewModel()
        {          
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            SignUpPageCommand = new RelayParameterizedCommand(async (parameter) => await SignUpAsync(parameter));
        }

        /// <summary>
        /// Attempt to log user in
        /// </summary>
        /// <param name="parameter">SecureString</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
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
            await RunCommand(() => this.IsLoggingIn, async () =>
             {
                 await Task.Delay(3000);                
                 var email = this.Email;
                 (parameter as IHavePassword).SecurePassword.Unsecure();
 
             });

            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Error;
            await Task.Delay(1);
        }

        public async Task SignUpAsync(object parameter)
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.SignUp;
            await Task.Delay(1);
        }
        #endregion

        #region Public Members
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        public string Email {get; set;}
        public bool IsLoggingIn
        {
            get
            {
                return LogInFlag;
            }
            set
            {
                LogInFlag = value;
                PropertyChangedEvent("IsLoggingIn");
            }
        }//Flagging the Login Button
        #endregion

        private bool LogInFlag;

        public string EmailTag { get; set; } = "Email";
        public string PasswordTag { get; set; } = "Password";

    }
}