using mymovies.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonsPage : ContentPage
    {
        SeasonsViewModel _viewModel;
        bool start = true;
        public SeasonsPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new SeasonsViewModel();

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

    }
}