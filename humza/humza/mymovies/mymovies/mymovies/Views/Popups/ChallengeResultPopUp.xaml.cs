using ViewModels.PopUpsViewModel;
using Xamarin.Forms.Xaml;

namespace Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChallengeResultPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ChallengeResultPopUp(string titleMessage, string mainMessage)
        {
            InitializeComponent();
            this.BindingContext = new ChallengeResultPopUpViewModel(titleMessage, mainMessage);
            

        }
    }
}