using mymovies.Helper;
using mymovies.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonsEpisodePage : ContentPage
    {
        SeasonEpisodeViewModel _viewModel;
        bool start = true;
        public SeasonsEpisodePage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = ApplicationViewModels._viewModelSeasonEpisode = new SeasonEpisodeViewModel();
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
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }
    }
}