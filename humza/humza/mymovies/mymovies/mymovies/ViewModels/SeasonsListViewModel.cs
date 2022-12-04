using mymovies.Helper;
using mymovies.Models;
using mymovies.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
namespace mymovies.ViewModels
{
    public class SeasonsListViewModel : BaseViewModel
    {
        private Seasons _selectedItem;
        public Command<Seasons> ItemTapped { get; }
        public ObservableCollection<Seasons> LstSeasons { get; }
        public SeasonsListViewModel()
        {
            LstSeasons = new ObservableCollection<Seasons>();
            LoadCommand = new Command(async () => { await RefreshDataAsync(); });
            ItemTapped = new Command<Seasons>(OnItemSelected);            
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
                            var lst = JsonConvert.DeserializeObject<List<Seasons>>(content);
                            lst.Reverse();
                            lst = lst.Where(x=>x.isReview == true && string.IsNullOrWhiteSpace(x.reviews.link) == false).ToList();
                            foreach (Seasons m in lst)
                            {
                                LstSeasons.Add(m);
                            }                            
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

            await Application.Current.MainPage.Navigation.PushAsync(new SeasonDetail(item), true);
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
