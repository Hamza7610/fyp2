using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using mymovies.Droid.Services;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationHelper))]
namespace mymovies.Droid.Services
{
    internal class NotificationHelper : INotification
    {
        //private static readonly string foregroundChannelId = "9001";
        //private static readonly Context context = global::Android.App.Application.Context;


        //public Notification ReturnNotif()
        //{
        //    // Building intent
        //    var intent = new Intent(context, typeof(MainActivity));
        //    intent.AddFlags(ActivityFlags.SingleTop);
        //    intent.PutExtra("Mymovies", "Downloading movies");

        //    var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.UpdateCurrent);

        //    var notifBuilder = new Notification.Builder(context, foregroundChannelId)
        //        .SetContentTitle("Mymovies")
        //        .SetContentText("Downloading movies....")
        //        //.SetSmallIcon(Resource.Drawable.MetroIcon)
        //        .SetOngoing(true)
        //        .SetContentIntent(pendingIntent);

        //    // Building channel if API verion is 26 or above
        //    if (global::Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.O)
        //    {
        //        NotificationChannel notificationChannel = new NotificationChannel(foregroundChannelId, "Mymovies", NotificationImportance.High)
        //        {
        //            Importance = NotificationImportance.High
        //        };
        //        notificationChannel.EnableLights(true);
        //        notificationChannel.EnableVibration(true);
        //        notificationChannel.SetShowBadge(true);
        //        notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 });

        //        if (context.GetSystemService(Context.NotificationService) is NotificationManager notifManager)
        //        {
        //            notifBuilder.SetChannelId(foregroundChannelId);
        //            notifManager.CreateNotificationChannel(notificationChannel);
        //        }
        //    }

        //    return notifBuilder.Build();
        //}
    }
}