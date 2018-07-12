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
        
        #endregion

        #region Constructors
        public SignUpViewModel()
        {          
            SignUpCommand = new RelayParameterizedCommand(async (parameter) => await SignUpAsync(parameter));
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
            await RunCommand(() => this.IsLoggingIn, async () =>
             {
                 await Task.Delay(3000);                
                 var email = this.Email;
                 (parameter as IHavePassword).SecurePassword.Unsecure();
 
             });
           // ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Error;
            await Task.Delay(1);
        }
        #endregion

        #region Public Members
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.SignUp;

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