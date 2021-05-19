using Delivery_Boy.Model;
using Delivery_Boy.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Delivery_Boy.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private Users user;

        public Users User
        {
            get { return user; }
            set {
                user = value;
                OnPropertyChanged("User");
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set {
                email = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { 
                password = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }




        public LoginCommand LoginCommand { get; set; }

        public LoginVM()
        {
            User = new Users();
            LoginCommand = new LoginCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Login()
        {

            bool canlogin = await Users.Login(User.Email, User.Password);
            if (canlogin)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "There was an error logging you in", "Okay");
            }
        }

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));

        }
    }
}
