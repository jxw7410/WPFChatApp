using System;
using System.Windows.Input;

namespace WPFChatApp
{ 
    public class RelayParameterizedCommand : ICommand
    {


        private Action<object> thisAction;
        public RelayParameterizedCommand(Action<object> action)
        {
            thisAction = action;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


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

