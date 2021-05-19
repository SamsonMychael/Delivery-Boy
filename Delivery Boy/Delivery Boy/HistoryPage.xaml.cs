using Delivery_Boy.Model;
using Delivery_Boy.ViewModel;
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
    public partial class HistoryPage : ContentPage
    {
        AddVM viewModel;
        public HistoryPage()
        {
            InitializeComponent();
            viewModel = new AddVM();
            BindingContext = viewModel;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            { 
               
               var posts = await Post.Read();
                PostListView.ItemsSource = posts;
                
            }
            catch(Exception ex)
            {

            }
            


        }
       
        private void PostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedpost = PostListView.SelectedItem as Post;
            if(selectedpost != null)
            {
                Navigation.PushAsync(new PostListPage(selectedpost));
            }
            else
            {
                DisplayAlert("Error", "First select one place", "Ok");
            }
        }
    }
}