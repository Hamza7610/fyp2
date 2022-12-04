
using mymovies.Helper;
using mymovies.Models;
using mymovies.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mymovies
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            ApplicationVariables.LoadApplicationVariables();
            var deviceId = Preferences.Get("my_deviceId", string.Empty);
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                deviceId = System.Guid.NewGuid().ToString();
                Preferences.Set("my_deviceId", deviceId);
            }
            Routing.RegisterRoute(nameof(SeasonsEpisodePage), typeof(SeasonsEpisodePage));
            Routing.RegisterRoute(nameof(SeasonDetailPage), typeof(SeasonDetailPage));            
            Routing.RegisterRoute(nameof(DownloadPage), typeof(DownloadPage));
            Routing.RegisterRoute(nameof(SignUpPage),typeof(SignUpPage));
            Routing.RegisterRoute(nameof(ForgotPasswordPage),typeof(ForgotPasswordPage));
            Routing.RegisterRoute(nameof(MoviesList), typeof(MoviesList));
            Routing.RegisterRoute(nameof(SeasonsPage),typeof(SeasonsPage));
            Routing.RegisterRoute(nameof(SeasonsList),typeof(SeasonsList));
            Routing.RegisterRoute(nameof(ProfilePage),typeof(ProfilePage));

            if (!String.IsNullOrEmpty(ApplicationVariables.Session_ID) && ApplicationVariables.User_ID > 0)
            {
                if (User.ApiLoginSession())
                {
                    MainPage = new LoggedInAppShell();
                }
                else
                {
                    MainPage = new AppShell();
                }

            }
            else
            {
                MainPage = new AppShell();
            }
        }

       

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            if (ApplicationViewModels._Player != null) 
            {
                ApplicationViewModels._Player?.Pause();
            }
        }

        protected override void OnResume()
        {
        }
    }
}
