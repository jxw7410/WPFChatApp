using System;
using System.Windows.Input;

namespace WPFChatApp.Core
{ 
    public class RelayParameterizedCommand : ICommand
    {


        private Action<object> thisAction;
        public RelayParameterizedCommand(Action<object> action)
        {
            thisAction = action;
        }


        public event EventHandler CanExecuteChanged = (sender, e) => { };

          


        public bool CanExecute(object parameter)
        {       
                return true;       
        }


        public void Execute(object parameter)
        {
            thisAction(parameter);
        }
    }
}

