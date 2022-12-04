using ViewModels.PopUpsViewModel;
using Xamarin.Forms.Xaml;

namespace Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {


        public DefaultPopUp(string titleMessage, string mainMessage)
        {
            InitializeComponent();
            this.BindingContext = new DefaultPopUpViewModel(titleMessage, mainMessage);
        }

    }
}