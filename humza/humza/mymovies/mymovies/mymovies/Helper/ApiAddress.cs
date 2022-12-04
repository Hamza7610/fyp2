using System;
using System.Collections.Generic;
using System.Text;

namespace mymovies.Helper
{
    class ApiAddress
    {
        public static string host = "https://mymovies.pk";
        //public static string host = "http://192.168.100.1";
        public static Uri GetSeasons()
        {
            return new Uri(host + "/season/get");
        }
        public static Uri GetMovies()
        {
            return new Uri(host + "/movie/get");
        }
        public static Uri UpdateReview(string id) 
        {
            return new Uri(host + "/mob/updateview/"+id);
        }
        public static Uri UpdateWatchingMovie()
        {
            return new Uri(host + "/mob/updatewatchingmovie");
        }
        public static Uri UpdateWatchingSeason()
        {
            return new Uri(host + "/mob/updatewatchingseason");
        }
        public static string GetMoviesStoragelink(string filename) 
        {
            return "https://mymovies.pk/storage/movies/" + filename;
        }
        public static Uri GetSeasonDetails(string id)
        {
            return new Uri(host + "/season/getseasondetail/"+id);
        }
        public static Uri GetSeasonEpisodes(string id)
        {
            return new Uri(host + "/season/getseasonepisodes/"+id);
        }
        public static Uri Storeuser()
        {
            return new Uri(host + "/mob/createuser");
        }
        public static Uri Auth()
        {
            return new Uri(host + "/mob/auth");
        }
        public static Uri AuthSession()
        {
            return new Uri(host + "/mob/authsession");
        }
        public static Uri Logout()
        {
            return new Uri(host + "/mob/logout");
        }
        public static Uri GetUser()
        {
            return new Uri(host + "/mob/getuser");
        }
        public static Uri CreateMovieRequest()
        {
            return new Uri(host + "/mob/requestmovie");
        }        
        public static Uri ChangePassword()
        {
            return new Uri(host + "/mob/changepassword");
        }

        public static Uri ForgetPassword()
        {
            return new Uri(host + "/mob/forgetpassword");
        }
    }

}
