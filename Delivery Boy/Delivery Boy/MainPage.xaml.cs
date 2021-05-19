using Delivery_Boy.Model;
using Delivery_Boy.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Delivery_Boy
{
    public partial class MainPage : ContentPage
    {
        LoginVM viewModel;
       
        public MainPage()
        {
            InitializeComponent();
            viewModel = new LoginVM();
           
            BindingContext = viewModel;

           // var assembly = typeof(MainPage);

           // iconimage.Source = ImageSource.FromResource("Delivery_Boy.Assets.Images.travel.png", assembly);
        }

         private void RegisterButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

       

        

           
       
    }
}
