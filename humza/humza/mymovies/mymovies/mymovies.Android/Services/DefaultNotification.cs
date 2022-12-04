using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using Java.Lang;

namespace mymovies.Droid.Services
{
    class DefaultNotification
    {
        static readonly int NOTIFICATION_ID = 1010101010;
        static readonly string CHANNEL_ID = "mymovies_notification";
        internal static readonly string COUNT_KEY = "Percentage";
        internal static Context AppContext = null;
        public static string MovieName = "";
        public static void CreateNotificationChannel(Context app)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var name = "MyMovies";
            var description = "Downloaded Movies";
            var channel = new NotificationChannel(CHANNEL_ID, name, NotificationImportance.Default)
            {
                Description = description
            };

            var notificationManager = (NotificationManager)app.GetSystemService("notification");
            notificationManager.CreateNotificationChannel(channel);
            AppContext = app;
        }
        public static void GenerateNotification()
        {

            var intent = new Intent(AppContext, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);


            var pendingIntent = PendingIntent.GetActivity(AppContext,
                                                          NOTIFICATION_ID,
                                                          intent,
                                                          PendingIntentFlags.OneShot);

            var notificationBuilder = new Notification.Builder(AppContext, CHANNEL_ID)
                                      .SetSmallIcon(Resource.Drawable.logo)
                                      .SetContentTitle("MyMovies")
                                      .SetContentText($"{MovieName} downloaded.")
                                      .SetAutoCancel(true)
                                      .SetSmallIcon(Resource.Drawable.logo)
                                      .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManagerCompat.From(AppContext);
            notificationManager.Notify(NOTIFICATION_ID, notificationBuilder.Build());

        }
    }
}