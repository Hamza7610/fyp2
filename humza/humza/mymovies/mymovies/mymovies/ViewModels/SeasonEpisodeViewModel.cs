using mymovies.Helper;
using mymovies.Models;
using mymovies.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
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
    [QueryProperty(nameof(Season_detail_id), nameof(Season_detail_id))]
    public class SeasonEpisodeViewModel : BaseViewModel
    {
        private SeasonEpisodes _selectedItem;

        public Command<SeasonEpisodes> ItemTapped { get; }
        public Command<SeasonEpisodes> StartDownloadCommand { get; }
        public ObservableCollection<SeasonEpisodes> LstSeasons { get; }

        private string season_detail_id;
        public string Season_detail_id
        {
            get { return season_detail_id; }
            set
            {
                season_detail_id = value;
                //LoadCommand.Execute(null);
            }
        }
        public SeasonEpisodeViewModel()
        {
            LstSeasons = new ObservableCollection<SeasonEpisodes>();
            LoadCommand = new Command(async () => { await RefreshDataAsync(); });
            ItemTapped = new Command<SeasonEpisodes>(OnItemSelected);
            StartDownloadCommand = new Command<SeasonEpisodes>(async (obj) => { await OnStartDownloadCommand(obj); });
        }
        private async Task OnStartDownloadCommand(SeasonEpisodes item)
        {
            try
            {
                await DownloadMoviesDatabase.CreateTable();
                var freeExternalStorage = Android.OS.Environment.ExternalStorageDirectory.UsableSpace;
                long threeGB = 3221223823;
                if (freeExternalStorage < threeGB)
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Not Enough Space")); return;

                }
                if (await DownloadMoviesDatabase.GetDownloadMoviesAsync(item.episode, item.season_detail_id, item.season_id) == null)
                {
                    await Seasons.UpdateWatchingSeason(season_detail_id);
                    byte[] img = null;
                    using (HttpClient client = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler()))
                    {

                        img = await client.GetByteArrayAsync(item.image_path);
                    }
                    await DownloadMoviesDatabase.CreateDownloadMovies(new DownloadMovies
                    {
                        name = item.episode,
                        image_path = img,
                        filename = "",
                        duration = item.duration,
                        isCompleted = false,
                        description = "",
                        url = ApiAddress.host+item.filename,
                        season_detail_id = item.season_detail_id,
                        season_id = item.season_id,
                        percentage = "0"
                    });
                    DependencyService.Get<IAndroidService>().StartService();
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Success", "Season Episode Added to downloading Queue"));
                }
                else { await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Season Episode already in downloading queue")); return; }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        async Task RefreshDataAsync()
        {
            if (IsBusy)
            {
                if (LstSeasons.Count > 0)
                {
                    IsBusy = false;
                    return;
                }

            }
            if (LstSeasons.Count == 0)
            {
                IsBusy = true;
                try
                {
                    using (Client = new HttpClient())
                    {
                        HttpResponseMessage response = await Client.GetAsync(ApiAddress.GetSeasonEpisodes(Season_detail_id));
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            LstSeasons.Clear();
                            foreach (SeasonEpisodes m in JsonConvert.DeserializeObject<ObservableCollection<SeasonEpisodes>>(content))
                            {
                                LstSeasons.Add(m);
                            }
                            LastId = LstSeasons.Last().id;
                        }
                    }
                }
                catch
                {

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
        SeasonEpisodes SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        public async void OnItemSelected(SeasonEpisodes item)
        {
            if (IsLoading)
            {
                return;
            }
            if (item == null)
                return;

            await Seasons.UpdateWatchingSeason(season_detail_id);
            IsLoading = true;            
            FileVideoSource fileVideoSource = new FileVideoSource
            {
                File = ApiAddress.host + item.filename
            };
            ApplicationViewModels.ChangeSeasonEpisodeIsLoading(false);
            await Application.Current.MainPage.Navigation.PushAsync(new PlayVideoPage(fileVideoSource), true);
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
