using Delivery_Boy.Model;
using Delivery_Boy.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery_Boy.ViewModel
{
    public class LogoutVM
    {
        public LogoutCommand LogoutCommand { get; set; }

        public LogoutVM()
        {
            LogoutCommand = new LogoutCommand(this);
        }

        public async void Logout()
        {
            bool response = await App.Current.MainPage.DisplayAlert("", "Do you want to Logout?", "Yes", "No");
            if (response)
            {
                
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
                return;
        }
    }
}
