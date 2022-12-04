using mymovies.Helper;
using mymovies.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace mymovies.Droid.Services
{
    public interface IDownloader
    {
        void DownloadFile(DownloadMovies url);
        event EventHandler<DownloadEventArgs> OnFileDownloaded;
    }
    public class DownloadEventArgs : EventArgs
    {
        public bool FileSaved = false;
        public DownloadEventArgs(bool fileSaved)
        {
            FileSaved = fileSaved;
        }
    }
    class Download : IDownloader
    {
        public event EventHandler<DownloadEventArgs> OnFileDownloaded;        
        static DownloadMovies current = null;
        public async void DownloadFile(DownloadMovies downloadMovies)
        {
            
            ApplicationVariables.Download = true;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string pathToNewFolder = Path.Combine(documentsPath, "movies");
            if (!Directory.Exists(pathToNewFolder))
            {
                Directory.CreateDirectory(pathToNewFolder);
            }

            try
            {
                string pathToNewFile = Path.Combine(pathToNewFolder, Path.GetFileName(downloadMovies.url));
                var downloadFileUrl = downloadMovies.url;
                var destinationFilePath = pathToNewFile;
                downloadMovies.filename = pathToNewFile;
                current = downloadMovies;
                ApplicationVariables.cancelToken = new CancellationTokenSource();
                var client = new HttpClientDownloadWithProgress(downloadFileUrl, destinationFilePath, ApplicationVariables.cancelToken.Token);
                client.ProgressChanged += DownloadProgressCallback;
                await DownloadMoviesDatabase.CreateDownloadMovies(downloadMovies);
                ApplicationVariables.current = current;
                ApplicationVariables.webClient = client;
                await client.StartDownload();               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));

                ApplicationVariables.current = null;
                ApplicationVariables.webClient = null;
            }
        }
        private async void DownloadProgressCallback(long? totalFileSize, long totalBytesDownloaded, double? progressPercentage)
        {
            current.percentage = progressPercentage?.ToString();
            if (progressPercentage != null && progressPercentage == 100) 
            {
                ApplicationVariables.current.isCompleted = true;
                ApplicationVariables.Download = false;
            }
            await DownloadMoviesDatabase.CreateDownloadMovies(current);
        }
        private async void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
            }
            else
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(true));

                current.isCompleted = true;
                await DownloadMoviesDatabase.CreateDownloadMovies(current);

                //DefaultNotification.GenerateNotification();
            }

            ApplicationVariables.Download = false;
        }

    }

}