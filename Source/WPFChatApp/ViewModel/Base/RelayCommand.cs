using System;
using System.Windows.Input;

namespace WPFChatApp
{
    public class RelayCommand : ICommand
    {


        private Action thisAction;
        public RelayCommand(Action action)
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
            if (parameter != null)
                return true;
            return false;
        }


        public void Execute(object parameter)
        {
            thisAction();
        }
    }
 }
