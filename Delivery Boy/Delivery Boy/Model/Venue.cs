using Delivery_Boy.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Boy.Model
{
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
       
        public int distance { get; set; }
        public string cc { get; set; }
        public string country { get; set; }
      
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string crossStreet { get; set; }
    }

  
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        
       
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }

        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var URL = VenueRoot.GenerateUrl(latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(URL);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venues = venueRoot.response.venues as List<Venue>;
            }
            return venues;
        }


    }

    public class Response
    {
        public IList<Venue> venues { get; set; }
        
    }

    

    public class VenueRoot
    {
        public Response response { get; set; }
        public static string GenerateUrl(double latitude , double longitude)
        {
            return string.Format(Constants.VENUE_SEARCH,latitude,longitude, Constants.Client_Id, Constants.Client_Secret, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
