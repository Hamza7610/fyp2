using mymovies.Helper;
using mymovies.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Views.Popups;
using Xamarin.Forms;

namespace mymovies.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        private User _user;
        private string oldpass;
        private string newpass;
        private string newpass2;
        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public Command ChangePasswordCommand { get; }
        public string Oldpass { get => oldpass; set => SetProperty(ref oldpass, value); }
        public string Newpass { get => newpass; set => SetProperty(ref newpass, value); }
        public string Newpass2 { get => newpass2; set => SetProperty(ref newpass2, value); }
        private Command GetUser { get; }
        public ProfilePageViewModel() 
        {
            ChangePasswordCommand = new Command(async ()=> { await ChangePassword(); });
            GetUser = new Command(GetUserCommand);
            
        }

        private async void GetUserCommand(object obj)
        {
            User = await User.GetUser();
        }

        private async Task ChangePassword()
        {
            if (string.IsNullOrWhiteSpace(Oldpass) || string.IsNullOrWhiteSpace(newpass) || string.IsNullOrWhiteSpace(newpass2)) 
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Please enter change password details, try again"));
                return;
            }
            if (newpass != newpass2) 
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Both Passwords do not match, try again"));
                return;
            }
            if (newpass2.Length < 8 || !Constants.ValidatePassword(newpass2))
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Password must be between 8 and 15 characters long.must " +
                    "contain at least one number,must contain at least one uppercase letter,must contain at least one lowercase letter., try again"));
                return;
            }
            if (await User.ChangePassword(Oldpass, Newpass2))
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Success", "Password has been changed"));
            }
            else 
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Old Password doesnt match"));
            }
        }
        public void OnAppearing()
        {
            GetUser.Execute(null);
        }
    }
}
