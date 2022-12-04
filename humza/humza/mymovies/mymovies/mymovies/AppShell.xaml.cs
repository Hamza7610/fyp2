using mymovies.Helper;
using mymovies.Models;
using mymovies.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mymovies
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DownloadMoviesDatabase.CreateTable();
                await Utility.CheckInternet();                
            });
            InitializeComponent();
            

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
