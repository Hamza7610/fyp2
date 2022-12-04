using mymovies.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadPage : ContentPage
    {
        bool start = true;
        DownloadsViewModel _viewModel;
        public DownloadPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new DownloadsViewModel();
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (start)
            {
                _viewModel.OnAppearing();
                start = false;
            }

        }
    }
}