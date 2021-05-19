
using Delivery_Boy.Model;
using Delivery_Boy.ViewModel;
using Plugin.Geolocator;
using SQLite;
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
    public partial class Travellerpage : ContentPage
    {
        TravelVM viewModel;
        public Travellerpage()
        {
            InitializeComponent();
            viewModel = new TravelVM();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            loading.IsVisible = true;
            loading.IsRunning = true;

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();


            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
            VenueListView.ItemsSource = venues;


            loading.IsRunning = false;
            loading.IsVisible = false;


        }

        
            

        
    }
}