using mymovies.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace mymovies.Models
{
    public class Movies
    {
        public int id { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public string duration { get; set; }
        public string filename { get; set; }
        public int views { get; set; }
        public int iskid { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public string image_path { get; set; }
        public bool isReview
        {
            get { return reviews != null; }        
           
        }
        public MovieReviews reviews { get; set; }

        public static async Task UpdateCounter(int id)
        {
            try
            {
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.GetAsync(ApiAddress.UpdateReview(id.ToString()));
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }
        public static async Task UpdateWatchingMovie(int movie) 
        {            
            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                bodyProperties.Add(new KeyValuePair<string, string>("user_id", ApplicationVariables.User_ID.ToString()));
                bodyProperties.Add(new KeyValuePair<string, string>("movie_id", movie.ToString()));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.UpdateWatchingMovie(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        
                    }
                }
            }
            catch { }
        }
    }
}
