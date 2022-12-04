using mymovies.Helper;
using mymovies.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        MoviesViewModel _viewModel;
        bool start = true;
        public Home()
        {
            try

            {
                InitializeComponent();
                this.BindingContext = _viewModel = ApplicationViewModels._viewModelMovies = new MoviesViewModel();
            }
            catch
            {

            }

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

        private void Searchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.SearchCommand.Execute(null);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<IAndroidService>().StopService();
        }
    }


}