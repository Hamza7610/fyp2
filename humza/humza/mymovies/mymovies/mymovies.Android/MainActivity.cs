
using Android.App;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using mymovies.Droid.Services;
using mymovies.Helper;
using mymovies.Views;
using Xamarin.Forms;

namespace mymovies.Droid
{
    [Activity(Label = "Movie Hub", Icon = "@drawable/logo", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static bool isOnline = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Xam.Forms.VideoPlayer.Android.VideoPlayerRenderer.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this);
            this.Window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.TurnScreenOn);
            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            LoadApplication(new App());
            MessagingCenter.Subscribe<PlayVideoPage>(this, "allowLandScapePortrait", sender =>
            {
                if (Device.Idiom == TargetIdiom.Phone) { 
                    RequestedOrientation = ScreenOrientation.SensorLandscape; 
                }               

            });

            //during page close setting back to portrait
            MessagingCenter.Subscribe<PlayVideoPage>(this, "preventLandScape", sender =>
            {
                if (Device.Idiom == TargetIdiom.Phone) { RequestedOrientation = ScreenOrientation.Portrait; }
            });
            //DefaultNotification.CreateNotificationChannel(ApplicationContext);
            if (IsOnline())
            {
                DependencyService.Get<IAndroidService>().StartService();
            }
            //new NotificationHelper().ReturnNotif();


        }
        public bool IsOnline()
        {
            var cm = (ConnectivityManager)GetSystemService(ConnectivityService);
            isOnline = cm.ActiveNetworkInfo == null ? false : cm.ActiveNetworkInfo.IsConnected;
            return isOnline;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
    }
}