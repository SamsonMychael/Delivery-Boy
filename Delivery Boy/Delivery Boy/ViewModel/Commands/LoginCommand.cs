using Delivery_Boy.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Delivery_Boy.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM viewModel { get; set; }
        public LoginCommand(LoginVM loginVM)
        {
            viewModel = loginVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {

            var usr = (Users)parameter;
            if (usr == null)
                return false;

            if (string.IsNullOrEmpty(usr.Email) || string.IsNullOrEmpty(usr.Password))
                return false;
            return true;

        }

        public void Execute(object parameter)
        {
            viewModel.Login();
        }
    }
}
