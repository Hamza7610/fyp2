using mymovies.Helper;
using mymovies.Models;
using mymovies.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Views.Popups;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;

namespace mymovies.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private Movies _selectedItem;
        public Command<Movies> ItemTapped { get; }
        public ObservableCollection<Movies> LstMovies { get; }

        public Command<Movies> StartDownloadCommand { get; }
        public MoviesViewModel()
        {
            LstMovies = new ObservableCollection<Movies>();
            LoadCommand = new Command(async () => { await RefreshDataAsync(); });
            ItemTapped = new Command<Movies>(OnItemSelected);
           
            SearchCommand = new Command(() => { OnSearchTextChanged(); });
            StartDownloadCommand = new Command<Movies>(async (obj) => { await OnStartDownloadCommand(obj); });
        }

        private async Task OnStartDownloadCommand(Movies item)
        {
            try
            {
                var freeExternalStorage = Android.OS.Environment.ExternalStorageDirectory.UsableSpace;
                long threeGB = 3221223823;
                if (freeExternalStorage < threeGB)
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Not Enough Space")); return;

                }
                await DownloadMoviesDatabase.CreateTable();
                if (await DownloadMoviesDatabase.GetDownloadMoviesAsync(item.name) == null)
                {
                    await Movies.UpdateCounter(item.id);
                    await Movies.UpdateWatchingMovie(item.id);
                    byte[] img = null;
                    using (HttpClient client = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler()))
                    {

                        img = await client.GetByteArrayAsync(item.image_path);
                    }
                    await DownloadMoviesDatabase.CreateDownloadMovies(new DownloadMovies
                    {
                        name = item.name,
                        image_path = img,
                        filename = "",
                        duration = item.duration,
                        isCompleted = false,
                        description = item.description != null ? item.description.ToString() : "",
                        url = ApiAddress.GetMoviesStoragelink(item.filename),
                        season_detail_id = 0,
                        season_id = 0,
                        percentage = "0"
                    }); ;

                    DependencyService.Get<IAndroidService>().StartService();
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Success", "Movie Added to downloading Queue"));
                }
                else { await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Movie already in downloading queue")); return; }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private List<Movies> OriginalLstMovies;
        private void OnSearchTextChanged()
        {
            if (SearchedText != "")
            {
                List<Movies> searchedMovies = OriginalLstMovies.Where(x => x.name.ToLower().Contains(SearchedText.ToLower())).ToList();
                LstMovies.Clear();
                foreach (Movies m in searchedMovies)
                {
                    LstMovies.Add(m);
                }
            }
            else
            {
                LstMovies.Clear();
                foreach (Movies m in OriginalLstMovies)
                {
                    LstMovies.Add(m);
                }
            }
        }

        async Task RefreshDataAsync()
        {
            if (IsBusy)
            {
                if (LstMovies.Count > 0)
                {
                    IsBusy = false;
                    return;
                }

            }
            if (LstMovies.Count == 0)
            {
                IsBusy = true;
                try
                {
                    using (Client = new HttpClient())
                    {
                        HttpResponseMessage response = await Client.GetAsync(ApiAddress.GetMovies());
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            LstMovies.Clear();
                            foreach (Movies m in JsonConvert.DeserializeObject<ObservableCollection<Movies>>(content))
                            {
                                    LstMovies.Add(m);
                            }
                            LastId = LstMovies.Last().id;
                            OriginalLstMovies = LstMovies.ToList<Movies>();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    IsBusy = false;
                }
            }
            else
            {
                IsBusy = false;
            }

        }
        public Movies SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(Movies item)
        {
            if (IsLoading)
            {
                return;
            }
            if (item == null)
                return;

            IsLoading = true;            
            await Movies.UpdateCounter(item.id);
            await Movies.UpdateWatchingMovie(item.id);
            FileVideoSource fileVideoSource = new FileVideoSource
            {
                File = ApiAddress.GetMoviesStoragelink(item.filename)
            };
            ApplicationViewModels.ChangeMoviesIsLoading(false);
            await Application.Current.MainPage.Navigation.PushAsync(new PlayVideoPage(fileVideoSource), true);
        }

    

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
