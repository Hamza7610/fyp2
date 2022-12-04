using mymovies.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonDetailPage : ContentPage
    {
        SeasonDetailsViewModel _viewModel;
        bool start = true;
        public SeasonDetailPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new SeasonDetailsViewModel();
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