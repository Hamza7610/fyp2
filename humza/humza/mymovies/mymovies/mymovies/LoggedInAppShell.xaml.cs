using mymovies.Helper;
using mymovies.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views.Popups;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoggedInAppShell : Shell
    {
        public LoggedInAppShell()
        {
            InitializeComponent();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DownloadMoviesDatabase.CreateTable();
                await Utility.CheckInternet();
                
            });
        }
        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            await User.Logout();
            App.Current.Properties.Clear();
            await App.Current.SavePropertiesAsync();
            Application.Current.MainPage = new AppShell();
        }

        private async void RequestMovie_Clicked(object sender, EventArgs e)
        {
            string requestName = await DisplayPromptAsync("Request NEW MOVIE", "Here you request movie which you wanna watch or missed.","Add Request");
            if (requestName != null  && requestName != "") 
            {
               bool request = await User.RequestMovie(requestName);
                if (request)
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Success", "Request has been sent"));
                }
                else 
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Error in requesting movie"));
                }
            }
        }
    }
}