using Delivery_Boy.Model;
using Delivery_Boy.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Delivery_Boy.ViewModel
{
    public class RegisterVM : INotifyPropertyChanged
    {
        private Users user;

        public Users User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    Confirmpassword = this.Confirmpassword
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                     Confirmpassword = this.Confirmpassword
                };
                OnPropertyChanged("Password");
            }
        }
        private string confirmpassword;

        public string Confirmpassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    Confirmpassword = this.Confirmpassword

                };
                OnPropertyChanged("Confirmpassword");
            }
        }
        public RegisterCommand RegisterCommand { get; set; }
        public RegisterVM()
        {
            user = new Users();
            RegisterCommand = new RegisterCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Register(Users user)
        {
            Users.Register(user);
           await App.Current.MainPage.Navigation.PopAsync();

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
