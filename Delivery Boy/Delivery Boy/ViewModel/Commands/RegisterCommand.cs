using Delivery_Boy.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Delivery_Boy.ViewModel.Commands
{
    
    public class RegisterCommand : ICommand
    {
        public RegisterVM viewModel  { get; set; }

        public RegisterCommand(RegisterVM registerVM)
        {
            viewModel = registerVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Users user = (Users)parameter;
            if (user != null)
            {
                if(user.Password == user.Confirmpassword)
                {
                    if (string.IsNullOrEmpty(user.Email) || (string.IsNullOrEmpty(user.Password)))

                        return false;

                    return true;
                      
                }
                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Users user = (Users)parameter;
            viewModel.Register(user);
        }
    }
}
