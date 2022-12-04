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
    public partial class MoviesList : ContentPage
    {
        MoviesListViewModel vM;
        bool start = true;
        public MoviesList()
        {
            InitializeComponent();
            this.BindingContext = vM = new MoviesListViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (start)
            {
                vM.OnAppearing();
                start = false;
            }

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }
    }
}