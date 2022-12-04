//using MediaManager;
using System;
using Xamarin.Forms;

namespace mymovies.ViewModels
{
    [QueryProperty(nameof(MoviesItem), nameof(MoviesItem))]
    public class PlayMovieModel : BaseViewModel
    {

        private string movieUrl;
        public string MovieUrl
        {
            get => movieUrl;
            set => SetProperty(ref movieUrl, value);
        }
        private string movieItem;
        public string MoviesItem
        {
            get
            {
                return movieItem;
            }
            set
            {
                movieItem = Uri.UnescapeDataString(value);
                LoadItemId(movieItem);
            }
        }


        public void LoadItemId(string movieItem)
        {
            try
            {
                MovieUrl = movieItem;
            }
            catch (Exception)
            {
                //Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
