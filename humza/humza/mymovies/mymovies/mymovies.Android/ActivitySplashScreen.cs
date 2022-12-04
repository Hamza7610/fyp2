using Android.App;
using Android.Content;
using Android.OS;
namespace mymovies.Droid
{
    [Activity(Label = "MyMovies", MainLauncher = true)]
    public class ActivitySplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layoutSplashDesign);

            Handler h = new Handler();
            h.PostDelayed(new System.Action(() =>
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
                Finish();
            }), 2000);

        }
    }
}