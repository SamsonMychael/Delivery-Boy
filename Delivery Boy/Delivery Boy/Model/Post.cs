using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Boy.Model
{
    public class Post : INotifyPropertyChanged
    {

        private string id;

        public string Id
        {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged("Id");

            }
        }




        private string places;

        public string Places
        {
            get { return places; }
            set {
                places = value;
                OnPropertyChanged("Places");
            }
        }


      

      



        private string venuename;

        public string Venuename
        {
            get { return venuename; }
            set { 
                venuename = value;
                OnPropertyChanged("Venuename");
            }
        }


        private string categoryid;

        public string Categoryid
        {
            get { return categoryid; }
            set
            {
                categoryid = value;
                OnPropertyChanged("Categoryid");
            }
        }
    
        


        private string categoryname;

        public string Categoryname
        {
            get { return categoryname; }
            set {
                categoryname = value;
                OnPropertyChanged("Categoryname");
            }
        }


        private string address;

        public string Address
        {
            get { return address; }
            set {
                address = value;
                OnPropertyChanged("Address");
            }
        }


        private double lat;

        public double Lat
        {
            get { return lat; }
            set {
                lat = value;
                OnPropertyChanged("Lat");
            }
        }

        private double lng;

        public double Lng
        {
            get { return lng; }
            set {
                lng = value;
                OnPropertyChanged("Lng");
            }
        }


        private int distance;

        public int Distance
        {
            get { return distance; }
            set {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private string userid;

        public event PropertyChangedEventHandler PropertyChanged;

        public string UserId
        {
            get { return userid; }
            set {
                userid = value;
             
                OnPropertyChanged("UserId");
            }
        }
        private Venue venue;

        [JsonIgnore]
        public Venue Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                if (venue.categories != null)
                {
                    var firstcategory = venue.categories.FirstOrDefault();

                    if (firstcategory != null)
                    {
                        Categoryid = firstcategory.id;
                        Categoryname = firstcategory.name;
                    }
                }
                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Lat = venue.location.lat;
                    Lng = venue.location.lng;
                }
                Venuename = venue.name;
                
                UserId = App.user.Id;
                OnPropertyChanged("Venue");
            }
        }





        public static async Task<List<Post>> Read()
        {
           var posts = await App.mobileService.GetTable<Post>().Where(u => u.UserId == App.user.Id).ToListAsync();
            return posts;
        }

        public static async void Insert(Post posts)
        {
           await App.mobileService.GetTable<Post>().InsertAsync(posts);
            
        }
        public static async void Update(Post selectedpost)
        {
             await App.mobileService.GetTable<Post>().UpdateAsync(selectedpost);
            
        }
        public static async void Delete(Post selectedpost)
        {
            await App.mobileService.GetTable<Post>().DeleteAsync(selectedpost);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    
