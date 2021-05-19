using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Delivery_Boy.ViewModel.Commands
{
    public class LogoutCommand : ICommand
    {
        LogoutVM viewModel;

        public LogoutCommand(LogoutVM logoutVM)
        {
              viewModel = logoutVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Logout();
        }
    }
}
