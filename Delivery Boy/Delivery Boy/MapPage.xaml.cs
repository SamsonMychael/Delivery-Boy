using Delivery_Boy.Model;
using Delivery_Boy.ViewModel;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
    public partial class MapPage : ContentPage
    {
        LogoutVM viewModel;
        bool HasLoationPermission = false;
        public MapPage()
        {
            InitializeComponent();
            viewModel = new LogoutVM();
            BindingContext = viewModel;
            Getpermission();
        }
        private async void Getpermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                {
                    await DisplayAlert("Failed", "We need your Location access", "Okay");
                }
                var request = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();
                if (request == PermissionStatus.Granted)
                {
                    status = request;
                }
            }
            if (status == PermissionStatus.Granted)
            {
                HasLoationPermission = true;
                LocationMap.IsShowingUser = true;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (HasLoationPermission)
            {
                var Locator = CrossGeolocator.Current;
                Locator.PositionChanged += Locator_PositionChanged;
                await Locator.StartListeningAsync(TimeSpan.Zero, 100);
            }
            GetLocation();
            
          
            DisplayInMap();
        }

        private async void DisplayInMap()
        {
            var posts = await Post.Read();

            foreach (var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Lat, post.Lng);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.Venuename,
                        Address = post.Address,
                    };
                    LocationMap.Pins.Add(pin);
                }



                catch (NullReferenceException nre)
                { }

                catch (Exception ex)
                { }
            }
        }


    
        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            var Locator = CrossGeolocator.Current;
            Locator.PositionChanged -= Locator_PositionChanged;
            await Locator.StopListeningAsync();
        }

        private async void GetLocation()
        {
            var location = CrossGeolocator.Current;
            var pos = await location.GetPositionAsync();
            Movemap(pos);
        }
        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            Movemap(e.Position);
        }

        public void Movemap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            LocationMap.MoveToRegion(span);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}