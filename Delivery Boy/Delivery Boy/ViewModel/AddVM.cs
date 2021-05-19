using Delivery_Boy.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery_Boy.ViewModel
{
   public class AddVM
    {
        public AddCommand AddCommand { get; set; }

        public AddVM()
        {
            AddCommand = new AddCommand(this);
        }
        public void Navigate()
        {
          App.Current.MainPage.Navigation.PushAsync(new Travellerpage());
        }
    }
}
