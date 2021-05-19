using Delivery_Boy.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Delivery_Boy
{
    public partial class App : Application
    {
        public static string Databaselocation = string.Empty;

        public static MobileServiceClient mobileService = new MobileServiceClient("https://deliveryboy.azurewebsites.net");

        public static Users user = new Users();
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databasepath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            Databaselocation = databasepath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
