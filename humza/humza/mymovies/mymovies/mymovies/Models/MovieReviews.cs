using System;
using System.Collections.Generic;
using System.Text;

namespace mymovies.Models
{
    public class MovieReviews
    {
        private List<int> ratingLst = null;
        public int id { get; set; }
        public int movie_id { get; set; }
        public string description { get; set; }
        public string imdbrating { get; set; }
        public string IMDBRating { get { return imdbrating + "/10 IMDb"; } }
        public List<int> RatingList
        {
            get
            {
                if (ratingLst == null)
                {
                    ratingLst = new List<int>();
                    for (int i = 0; i < rating; i++)
                    {
                        ratingLst.Add(0);
                    }
                }
                return ratingLst;
            }
        }
        public string genre { get; set; }
        public int rating { get; set; }
        public string review { get; set; }
        public string link { get; set; }
    }
}
