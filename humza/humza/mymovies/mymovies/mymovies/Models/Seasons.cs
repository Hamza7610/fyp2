using mymovies.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace mymovies.Models
{
    public class Seasons
    {
        public int id { get; set; }
        public string name { get; set; }
        public int iskid { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public string image_path { get; set; }
        public bool isReview
        {
            get { return reviews != null; }

        }
        public SeasonReviews reviews { get; set; }
        public static async Task UpdateWatchingSeason(string season)
        {
            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                bodyProperties.Add(new KeyValuePair<string, string>("user_id", ApplicationVariables.User_ID.ToString()));
                bodyProperties.Add(new KeyValuePair<string, string>("season_detail_id", season));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.UpdateWatchingSeason(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                    }
                }
            }
            catch { }
        }
    }
    public class SeasonDetails
    {
        public int id { get; set; }
        public string season_detail { get; set; }
        public int season_id { get; set; }
        public string image_path { get; set; }
    }
    public class SeasonEpisodes
    {
        public int id { get; set; }
        public string episode { get; set; }
        public string duration { get; set; }
        public string filename { get; set; }
        public int season_detail_id { get; set; }
        public int season_id { get; set; }
        public string image_path { get; set; }
    }
}
