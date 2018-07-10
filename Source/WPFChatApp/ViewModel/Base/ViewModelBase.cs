using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace WPFChatApp
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void PropertyChangedEvent([CallerMemberName]string property = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        /// <summary>
        /// If flag is not set, then runs a command
        /// else flag is set, function is running, thus command action does not execute
        /// once action is finish, then flag is reset.
        /// </summary>
        /// <param name="updatingFlag">bool flag prop</param>
        /// <param name="action">The async action</param>
        /// <returns></returns>
        #region Command Helpers
        protected async Task RunCommand(Expression <Func<bool>> updatingFlag, Func<Task> action) //Expressions are runtime (dynamic) functions/parameters
        {
            //Check if flag is true
            if (updatingFlag.GetPropertyValue())
            {
                return; //It is running
            }

            updatingFlag.SetPropertyValue(true);

            //No Catch because we don't want to handle the errors yet, just ignore them.
            try
            {
                await action();
            }
            finally
            {
                updatingFlag.SetPropertyValue(false);
            }
        }
        #endregion
    }
}
