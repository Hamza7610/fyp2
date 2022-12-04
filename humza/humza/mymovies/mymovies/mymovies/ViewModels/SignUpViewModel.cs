using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using mymovies.Helper;
using Xamarin.Forms;

using mymovies.Models;
using Views.Popups;
using mymovies.Views;

namespace mymovies.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        private string name;
        private string email;
        private string password;
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }
        public string Name { get => name; set { SetProperty(ref name, value); } }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public SignUpViewModel()
        {
            LoginCommand = new Command(async () => { await LoginClicked(); });
            SignUpCommand = new Command(async () => { await SignUpClicked(); });
        }

        private async Task LoginClicked()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async Task SignUpClicked()
        {
            if (!IsBusy)
            {
                if (String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Name))
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Please enter signup details, try again"));
                    return;
                }                
                if (!Constants.IsValidEmail(Email))
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Email error, try again"));
                    return;
                }
                if (Password.Length < 8 || !Constants.ValidatePassword(Password))
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Password must be between 8 and 15 characters long.must " +
                        "contain at least one number,must contain at least one uppercase letter,must contain at least one lowercase letter., try again"));
                    return;
                }
                IsBusy = true;
                int createUser = await User.CreateUser(Name.Trim(), Email.Trim(), Password);
                if (createUser == Constants.Success)
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Success", "User created"));
                    Application.Current.MainPage = new LoggedInAppShell();
                }
                else if (createUser == Constants.Duplicate)
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Email Already exists please try another email"));
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Error creating the account"));
                }
                IsBusy = false;
            }
        }
        
    }
}
