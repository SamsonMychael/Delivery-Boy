using Delivery_Boy.Model;
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
    public partial class PostListPage : ContentPage
    {
        Post selectedpost;
        public PostListPage(Post selectedpost)
        {
            InitializeComponent();
            this.selectedpost = selectedpost;
            
            venuelabel.Text = selectedpost.Venuename;
            addresslabel.Text = selectedpost.Address;
            coordinateslabel.Text = $"{selectedpost.Lat},{ selectedpost.Lng}";
            distancelabel.Text = $"{selectedpost.Distance} m";
            placeEntry.Text = selectedpost.Places;
        }

        private async void updateButton_Clicked(object sender, EventArgs e)
        {
            
                selectedpost.Places = placeEntry.Text;
                /* using (SQLiteConnection cnn = new SQLiteConnection(App.Databaselocation))
                 {
                     cnn.CreateTable<Post>();
                     var rows = cnn.Update(selectedpost);

                     if (rows > 0)
                         DisplayAlert("Success", "Places inserted successfully", "Ok");
                     else
                         DisplayAlert("Failed", "Places failed to be inserted", "Ok");

                 }
                */
                try
            {

                Post.Update(selectedpost);
               await DisplayAlert("Success", "Updated successfully", "Ok");
            }
            catch(Exception ex)
            {
               await DisplayAlert("Failed", "Update failed Try Again", "Ok");
            }
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
           
                /*using (SQLiteConnection cnn = new SQLiteConnection(App.Databaselocation))
                {
                    cnn.CreateTable<Post>();
                    var rows = cnn.Delete(selectedpost);

                    if (rows > 0)
                        DisplayAlert("Success", "Places inserted successfully", "Ok");
                    else
                        DisplayAlert("Failed", "Places failed to be inserted", "Ok");

                }*/
                try
            {
                Post.Delete(selectedpost);
               await DisplayAlert("Success", "Deleted successfully", "Ok");
            }
            catch(Exception ex)
            {
              await  DisplayAlert("Failed", "failed to be Deleted", "Ok");
            }
        }
    }
}