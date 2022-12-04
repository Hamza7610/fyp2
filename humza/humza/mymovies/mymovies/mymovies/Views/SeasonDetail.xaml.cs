using mymovies.Models;
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
    public partial class SeasonDetail : ContentPage
    {
        DetailViewModel vm;
        public SeasonDetail(Seasons item)
        {
            InitializeComponent();
            BindingContext = vm = new DetailViewModel(item);
        }
    }
}