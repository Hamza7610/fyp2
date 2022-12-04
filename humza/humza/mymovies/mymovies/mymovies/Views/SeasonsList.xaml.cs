using mymovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonsList : ContentPage
    {
        SeasonsListViewModel _viewModel;
        bool start = true;
        public SeasonsList()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new SeasonsListViewModel();
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