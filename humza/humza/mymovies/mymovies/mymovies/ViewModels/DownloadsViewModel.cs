using mymovies.Helper;
using mymovies.Models;
using mymovies.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Views.Popups;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
namespace mymovies.ViewModels
{
    class DownloadsViewModel : BaseViewModel
    {
        private DownloadMovies _selectedItem;
        public Command<DownloadView> ItemTapped { get; }
        public ObservableCollection<DownloadView> LstMovies { get; }
        public Command<DownloadView> RemoveCommand { get; }

        public DownloadsViewModel()
        {
            LstMovies = new ObservableCollection<DownloadView>();
            LoadCommand = new Command(async () => { await RefreshDataAsync(); });
            ItemTapped = new Command<DownloadView>(async (obj) => { await OnItemSelectedAsync(obj); });
            RemoveCommand = new Command<DownloadView>(async (obj) => { await OnRemoveCommandAsync(obj); });
        }

        private async Task OnRemoveCommandAsync(DownloadView obj)
        {
            try {
                ApplicationVariables.CancelDownloading(new DownloadMovies(obj));
                DependencyService.Get<IAndroidService>().StopService();
            } catch 
            {
            }
            try
            {
                await DownloadMoviesDatabase.Remove(new DownloadMovies(obj));
            }
            catch
            {
            }
            try
            {
                if (File.Exists(obj.filename))
                {
                    File.Delete(obj.filename);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IsBusy = true;
        }

        async Task RefreshDataAsync()
        {
            LstMovies.Clear();
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
                    LstMovies.Clear();
                    foreach (DownloadMovies obj in await DownloadMoviesDatabase.GetDownloadMoviesListAsync())
                    {
                        LstMovies.Add(new DownloadView(obj));
                    }
                    if (LstMovies.Count == 0) {
                        DependencyService.Get<IAndroidService>().StopService();
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
        public DownloadMovies SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);

            }
        }

        async Task OnItemSelectedAsync(DownloadView item)
        {
            if (IsLoading)
            {
                return;
            }
            if (item == null)
                return;

            if (!item.isCompleted) { await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Download is still in progress, try again later")); return; }
            if (item.filename == "") { await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Downloaded file has errors, try again later")); return; }

            string filename = item.filename;
            if (!String.IsNullOrWhiteSpace(filename))
            {
                FileVideoSource fileVideoSource = new FileVideoSource
                {
                    File = filename
                };
                await Application.Current.MainPage.Navigation.PushAsync(new PlayVideoPage(fileVideoSource), true);
            }
           
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
