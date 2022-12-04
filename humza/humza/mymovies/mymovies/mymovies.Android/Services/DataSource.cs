using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using mymovies.Helper;
using mymovies.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace mymovies.Droid.Services
{
    class DataSource
    {
        Download downloader = new Download();
       

        public const int ServiceRunningNotifID = 9000;
        
        public void OnStartCommand()
        {
            try
            {
                Device.StartTimer(new TimeSpan(0, 0, 10), () =>
                {
                    if (!ApplicationVariables.Download)
                    {
                        List<DownloadMovies> o = DownloadMoviesDatabase.GetDownloadMoviesAsync();
                        if (o.Count > 0)
                        {
                            foreach (DownloadMovies obj in o)
                            {
                                if (MainActivity.isOnline)
                                {
                                    if (!ApplicationVariables.Download)
                                    {
                                        downloader.DownloadFile(obj);
                                    }
                                }
                            }
                        }
                        else
                        {
                            DependencyService.Get<IAndroidService>().StopService();
                        }


                    }
                    return true;
                });

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void StopService()
        {
        }


    }
}