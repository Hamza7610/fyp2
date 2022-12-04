using mymovies.Helper;
using mymovies.Models;
using mymovies.Views;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace mymovies.ViewModels
{
    [QueryProperty(nameof(Season_id), nameof(Season_id))]
    class SeasonDetailsViewModel : BaseViewModel
    {
        private SeasonDetails _selectedItem;

        public Command<SeasonDetails> ItemTapped { get; }
        public ObservableCollection<SeasonDetails> LstSeasons { get; }

        private string season_id;
        public string Season_id
        {
            get { return season_id; }
            set
            {
                season_id = value;
                //LoadCommand.Execute(null);
            }
        }
        public SeasonDetailsViewModel()
        {
            LstSeasons = new ObservableCollection<SeasonDetails>();
            LoadCommand = new Command(async () => { await RefreshDataAsync(); });
            ItemTapped = new Command<SeasonDetails>(OnItemSelected);

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
                        HttpResponseMessage response = await Client.GetAsync(ApiAddress.GetSeasonDetails(Season_id));
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            LstSeasons.Clear();
                            foreach (SeasonDetails m in JsonConvert.DeserializeObject<ObservableCollection<SeasonDetails>>(content))
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
        public SeasonDetails SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(SeasonDetails item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(SeasonsEpisodePage)}?{nameof(SeasonEpisodeViewModel.Season_detail_id)}={item.id}");
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
