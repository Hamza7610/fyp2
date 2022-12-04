using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.PopUpsViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyRewardsPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        DailyRewardsViewModel _viewModel;
        public DailyRewardsPopup(string type, string message)
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new DailyRewardsViewModel(type, message);
        }
    }
}