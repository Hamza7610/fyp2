namespace ViewModels.PopUpsViewModel
{
    class DefaultPopUpViewModel : PopUpBaseModel
    {
        public DefaultPopUpViewModel(string titleMessage, string mainMessage)
        {
            this.MainTitle = titleMessage;
            this.Message = mainMessage;
            if (titleMessage == "Error")
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
