using Delivery_Boy.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Delivery_Boy.ViewModel.Commands
{
    public class PostCommand : ICommand
    {
        TravelVM viewModel;
        public PostCommand(TravelVM viewModel)
        {
            this.viewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;
            if(post != null)
            {
                if (string.IsNullOrEmpty(post.Places))
                    return false;

                if(post.Venue != null)
                    return true;

                return false;
                        
            }
            return false;
        }

        public  void Execute(object parameter)
        {
            var post = (Post)parameter;
            viewModel.Getpost(post);
        }
    }
}
