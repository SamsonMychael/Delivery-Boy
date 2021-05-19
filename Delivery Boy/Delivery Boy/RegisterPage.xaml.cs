﻿using Delivery_Boy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Delivery_Boy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        RegisterVM viewModel;
        public RegisterPage()
        {
            InitializeComponent();
            viewModel = new RegisterVM();
            BindingContext = viewModel;
        }

         private void loginButton_Tapped(object sender, EventArgs e)
            {
             Navigation.PopAsync();
            }
        
    }
}