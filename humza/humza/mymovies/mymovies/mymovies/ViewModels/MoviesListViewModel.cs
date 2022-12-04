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
    public class MoviesListViewModel : BaseViewModel
    {
        private Movies _selectedItem;
        public Command<Movies> ItemTapped { get; }
        public ObservableCollection<Movies> LstMovies { get; }
        public MoviesListViewModel()
        {
            LstMovies = new ObservableCollection<Movies>();
            LoadCommand = new Command(async () => { await RefreshDataAsync(); });
            ItemTapped = new Command<Movies>(OnItemSelected);
           
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
                            var lst = JsonConvert.DeserializeObject<List<Movies>>(content);
                            lst.Reverse();
                            lst = lst.Where(x => x.isReview == true && string.IsNullOrWhiteSpace(x.reviews.link) == false).ToList();
                            foreach (Movies m in lst)
                            {
                                LstMovies.Add(m);
                            }                            
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

            
            await Application.Current.MainPage.Navigation.PushAsync(new MovieDetail(item), true);
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
