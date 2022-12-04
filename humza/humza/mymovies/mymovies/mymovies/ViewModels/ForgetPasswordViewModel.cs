using mymovies.Helper;
using mymovies.Models;
using mymovies.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Views.Popups;
using Xamarin.Forms;

namespace mymovies.ViewModels
{
    public class ForgetPasswordViewModel
    {
        private string email;
        public Command LoginCommand { get; }
        public Command ForgetPasswordCommand { get; }
        public string Email { get => email; set => email = value; }
        public ForgetPasswordViewModel()
        {
            LoginCommand = new Command(async () => { await OnLoginClicked(); });
            ForgetPasswordCommand = new Command(async () => { await ForgetPasswordClicked(); });
        }

        private async Task ForgetPasswordClicked()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Email cannot be empty"));
                return;
            }
            if (!Constants.IsValidEmail(Email))
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Please enter valid email, try again"));
                return;
            }
            int code = await User.ForgetPassword(Email);
            if (code == Constants.Success )
            {                
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Success", "Password has been changed, please check your mail"));
            }
            else if (code == Constants.Error)
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Error in Password Reset"));
            }
            else if (code == Constants.DosentExist)
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Email Doesn't exist in system"));
            }
            else 
            {
                await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Error in Password Reset"));
            }
        }

        private async Task OnLoginClicked()
        {
            await Shell.Current.Navigation.PopAsync();
        }

    }
}
