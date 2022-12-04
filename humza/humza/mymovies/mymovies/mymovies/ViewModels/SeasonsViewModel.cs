using mymovies.Helper;
using mymovies.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Seasons = mymovies.Models.Seasons;

namespace mymovies.ViewModels
{
    class SeasonsViewModel : BaseViewModel
    {
        private Seasons _selectedItem;

        public Command<Seasons> ItemTapped { get; }
        public ObservableCollection<Seasons> LstSeasons { get; }


        public SeasonsViewModel()
        {
            LstSeasons = new ObservableCollection<Seasons>();
            LoadCommand = new Command(async () => { await RefreshDataAsync(); });
            ItemTapped = new Command<Seasons>(OnItemSelected);
            LoadMoreCommand = new Command(async () => { await OnCollectionViewRemainingItemsThresholdReached(); });
            SearchCommand = new Command(() => { OnSearchTextChanged(); });
        }
        private List<Seasons> OriginalLstSeasons;
        private void OnSearchTextChanged()
        {
            if (SearchedText != "")
            {
                List<Seasons> searchedMovies = OriginalLstSeasons.Where(x => x.name.ToLower().Contains(SearchedText.ToLower())).ToList();
                LstSeasons.Clear();
                foreach (Seasons m in searchedMovies)
                {
                    LstSeasons.Add(m);
                }
            }
            else
            {
                LstSeasons.Clear();
                foreach (Seasons m in OriginalLstSeasons)
                {
                    LstSeasons.Add(m);
                }
            }
        }
        public async Task OnCollectionViewRemainingItemsThresholdReached()
        {
            if (End)
            {
                return;
            }
            if (IsBusyLoadMore)
            {
                return;

            }
            try
            {
                IsBusyLoadMore = true;
                Uri uri = new Uri("https://mymovies.pk/season/get/" + LastId);

                using (Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        if (content == "[]")
                        {
                            LastId = 0;
                        }
                        else
                        {
                            foreach (Seasons m in JsonConvert.DeserializeObject<ObservableCollection<Seasons>>(content))
                            {
                                LstSeasons.Add(m);
                            }
                            LastId = LstSeasons.Last().id;
                        }

                    }
                }
            }
            catch
            {
                LastId = 0;
            }
            finally
            {
                IsBusyLoadMore = false;
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
                        HttpResponseMessage response = await Client.GetAsync(ApiAddress.GetSeasons());
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            LstSeasons.Clear();
                            foreach (Seasons m in JsonConvert.DeserializeObject<ObservableCollection<Seasons>>(content))
                            {
                                LstSeasons.Add(m);
                            }
                            LastId = LstSeasons.Last().id;
                            OriginalLstSeasons = LstSeasons.ToList<Seasons>();
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
        public Seasons SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(Seasons item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(SeasonDetailPage)}?{nameof(SeasonDetailsViewModel.Season_id)}={item.id}");
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
