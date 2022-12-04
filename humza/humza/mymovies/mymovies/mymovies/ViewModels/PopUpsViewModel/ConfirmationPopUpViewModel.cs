using System.Threading.Tasks;
using Xamarin.Forms;

namespace ViewModels.PopUpsViewModel
{
    public class ConfirmationPopUpViewModel : PopUpBaseModel
    {
        private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        public Command OKCommand { get; }
        public Command CancelCommand { get; }
        private bool confirmation;

        private string yesButtonText;
        private string noButtonText;
        public string YesButtonText { get => yesButtonText; set => SetProperty(ref yesButtonText, value); }
        public string NoButtonText { get => noButtonText; set => SetProperty(ref noButtonText, value); }
        public ConfirmationPopUpViewModel(string titleMessage, string mainMessage, string yesButtonText = "Yes", string noButtonText = "No")
        {
            this.MainTitle = titleMessage;
            this.Message = mainMessage;
            OKCommand = new Command(() => { confirmation = true; tcs.SetResult(confirmation); });
            CancelCommand = new Command(() => { confirmation = false; tcs.SetResult(confirmation); });
            YesButtonText = yesButtonText;
            NoButtonText = noButtonText;
        }
        public Task<bool> GetValue()
        {
            return tcs.Task;
        }
    }
}
