using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.PopUpsViewModel
{
    public class DailyRewardsViewModel : PopUpBaseModel
    {
        public DailyRewardsViewModel(string type,string message) 
        {
            this.Message = message;
            this.Type = type;
            this.Image = type == "Coins" ? "coins.png" : "crystals.png";

        }
        private string type;
        private string image;
        public string Type { get => type; set => SetProperty(ref type, value); }
        public string Image { get => image; set => SetProperty(ref image, value); }
    }
}
