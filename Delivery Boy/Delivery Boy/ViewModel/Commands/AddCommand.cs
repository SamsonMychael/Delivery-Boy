using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Delivery_Boy.ViewModel.Commands
{
    public class AddCommand : ICommand
    {
        AddVM viewModel;
        public AddCommand(AddVM addVM)
        {
            viewModel = addVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Navigate();
        }
    }
}
