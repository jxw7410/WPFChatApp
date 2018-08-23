using System;
using System.Windows.Input;

namespace WPFChatApp.Core
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
            return true;
        }


        public void Execute(object parameter)
        {
            thisAction();
        }
    }
 }
