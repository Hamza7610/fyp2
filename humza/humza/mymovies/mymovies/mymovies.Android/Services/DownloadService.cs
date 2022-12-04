using Android.Content;
using mymovies.Droid.Services;
using mymovies.Helper;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(DownloadService))]
namespace mymovies.Droid.Services
{
    class DownloadService : IAndroidService
    {
        private static Context context = global::Android.App.Application.Context;
        private static Task download = null;
        public void StartService()
        {
            if (download == null) 
            {
                download = new Task(() => {
                    DataSource d = new DataSource();
                    d.OnStartCommand();
                });
                download.Start();
            }         
            
        }

        public void StopService()
        {
            download.Dispose();
        }
    }
}

