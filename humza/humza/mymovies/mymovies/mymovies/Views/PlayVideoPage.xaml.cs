using mymovies.Helper;
using System;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayVideoPage : ContentPage
	{
        private VideoSource _videoSource;
        bool tapped = true;

        public PlayVideoPage(VideoSource videoSource)
        {
            _videoSource = videoSource;
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            videoPlayer.Source = _videoSource;
            if (Device.RuntimePlatform == Device.Android)
            {
                Shell.SetNavBarIsVisible(this, false);
                MessagingCenter.Send(this, "allowLandScapePortrait");
            }
            ApplicationViewModels._Player = videoPlayer;
        }

        private async void VideoPlayer_PlayCompletion(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void VideoPlayer_PlayError(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnDisappearing()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                Shell.SetNavBarIsVisible(this, true);
                MessagingCenter.Send(this, "preventLandScape");

            }
            videoPlayer.Stop();
            base.OnDisappearing();
            ApplicationViewModels._Player = null;
        }

        private void VideoPlayer_BufferingStart(object sender, EventArgs e)
        {

        }

        private void VideoPlayer_BufferingEnd(object sender, EventArgs e)
        {

        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Shell.SetNavBarIsVisible(this, tapped);
            tapped = !tapped;
        }
    }
}