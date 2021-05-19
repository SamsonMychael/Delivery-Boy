using Delivery_Boy.Model;
using Delivery_Boy.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Delivery_Boy.ViewModel
{
    public class TravelVM : INotifyPropertyChanged
    {

        public PostCommand PostCommand { get; set; }

        private Post post;

        public Post Post
        {
            get { return post; }
            set {
                post = value;
                OnPropertyChanged("Post");
            }
        }
        private string places;

        public string Places
        {
            get { return places; }
            set { 
                places = value;
                Post = new Post()
                {
                    Places = this.Places,
                    Venue = this.Venue,
                   
                };
                OnPropertyChanged("Places");
            }
        }
      



        private Venue venue;

        public event PropertyChangedEventHandler PropertyChanged;

        public Venue Venue
        {
            get { return venue; }
            set { 
                venue = value;
                Post = new Post()
                {
                    Places = this.Places,
                    Venue = this.Venue,
                    
                };
                OnPropertyChanged("Venue");
            }
        }


        public TravelVM()
        {
            Post = new Post();
            Venue = new Venue();
            PostCommand = new PostCommand(this);
        }

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        public async void Getpost( Post post)
        {
            try
            {
                Post.Insert(post);
                await App.Current.MainPage.DisplayAlert("Success", "Successfully Added", "Okay");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (NullReferenceException nre)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Insertion failed", "Okay");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Insertion failed", "Okay");
            }
        }
    }
}
