namespace ViewModels.PopUpsViewModel
{
    class ChallengeResultPopUpViewModel : PopUpBaseModel
    {
        public ChallengeResultPopUpViewModel(string titleMessage, string mainMessage)
        {
            this.MainTitle = titleMessage;
            this.Message = mainMessage;
            if (titleMessage == "Lost")
            {
                TitleColor = "#FF0000";
            }
            else
            {
                TitleColor = "#ffffff";
            }
        }       

        private string titleColor;

        public string TitleColor { get => titleColor; set => SetProperty(ref titleColor, value); }
       
    }
}
