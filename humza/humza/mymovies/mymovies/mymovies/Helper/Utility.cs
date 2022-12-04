using mymovies.Models;
using mymovies.ViewModels;
using mymovies.Views;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace mymovies.Helper
{
    public class Utility
    {
        public const string DatabaseFilename = "mymovies.db3";
        private static SQLiteAsyncConnection database;
        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteAsyncConnection(DatabasePath, Flags);
                }
                return database;
            }
        }
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache | SQLite.SQLiteOpenFlags.ProtectionComplete;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
        internal async static Task<bool> IsInternet()
        {
            try
            {
                Uri uri = new Uri("https://mymovies.pk/movie/get");

                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        object x = JsonConvert.DeserializeObject<ObservableCollection<Movies>>(content);
                        return true;
                    }
                }
            }
            catch
            {

            }
            return false;
        }

        internal async static Task CheckInternet()
        {
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                Application.Current.MainPage = new AppShellOffline();
            }
            else
            {
                bool connection = await Utility.IsInternet();
                if (!connection)
                {
                    Application.Current.MainPage = new AppShellOffline();
                }
            }
        }
    }
    public class ApplicationVariables
    {
        public static DownloadMovies current;
        public static HttpClientDownloadWithProgress webClient;
        public static bool Download = false;
        public static CancellationTokenSource cancelToken;
        
        public static bool GetDifferenceInHours(DateTime counter)
        {
            var hours = (DateTime.Now - counter).TotalHours;
            return hours > 1;
        }
        public static bool GetDifferenceInDays(DateTime counter)
        {
            var hours = (DateTime.Now - counter).TotalDays;
            return hours > 0.8;
        }
        public static void CancelDownloading(DownloadMovies removed)
        {
            if (removed != null && current != null && webClient !=  null)
            {
                if (removed.ID == current.ID && removed.name == current.name && current.filename == removed.filename)
                {
                    cancelToken.Cancel();
                    current = null;
                    Download = false;
                    webClient.Dispose();                    
                }
            }
           
        }
        public static int User_ID;
        public static string Session_ID;
        public static void LoadApplicationVariables()
        {
            Application.Current.Properties.TryGetValue("user_id", out object user_id);
            Application.Current.Properties.TryGetValue("session_id", out object session_id);

            ApplicationVariables.User_ID = user_id != null ? Convert.ToInt32(user_id) : 0;
            ApplicationVariables.Session_ID = session_id != null ? (string)session_id : "";
        }
        public static void SetApplicationVariables()
        {


        }

        public static void ClearApplicationVariables()
        {
            ApplicationVariables.User_ID = 0;
            ApplicationVariables.Session_ID = "";
        }
    }

    public class ApplicationViewModels
    {
        public static MoviesViewModel _viewModelMovies;
        public static SeasonEpisodeViewModel _viewModelSeasonEpisode;
        public static Xam.Forms.VideoPlayer.VideoPlayer _Player;
        public static void ChangeMoviesIsLoading(bool loading)
        {
            _viewModelMovies.IsLoading = loading;
        }
        public static void ChangeSeasonEpisodeIsLoading(bool loading)
        {
            _viewModelSeasonEpisode.IsLoading = loading;
        }
    }
}
