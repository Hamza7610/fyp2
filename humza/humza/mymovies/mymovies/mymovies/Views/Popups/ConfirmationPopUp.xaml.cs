using ViewModels.PopUpsViewModel;
using Xamarin.Forms.Xaml;

namespace Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ConfirmationPopUpViewModel viewModel;
        public ConfirmationPopUp(string titleMessage, string mainMessage, string yesButtonText = "Yes", string noButtonText = "No")
        {
            InitializeComponent();
            viewModel = new ConfirmationPopUpViewModel(titleMessage, mainMessage, yesButtonText, noButtonText);
            this.BindingContext = viewModel;

        }
    }
}