using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using mymovies.Views;
using Xamarin.Forms;
using mymovies.Models;
using mymovies.Helper;
using Views.Popups;

namespace mymovies.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string name;
        private string email;
        private string password;
        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }
        public Command ForgetPasswordCommand { get; }
        public string Name { get => name; set { SetProperty(ref name, value); } }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SignUpCommand = new Command(async () => { await OnSignUpClicked(); });
            ForgetPasswordCommand = new Command(async () => { await OnForgetPasswordClicked(); });
        }

        private async Task OnForgetPasswordClicked()
        {
            await Shell.Current.GoToAsync($"{nameof(ForgotPasswordPage)}");
        }

        private async Task OnSignUpClicked()
        {
            await Shell.Current.GoToAsync($"{nameof(SignUpPage)}");
        }

        private async void OnLoginClicked()
        {
            if (!IsBusy)
            {
                if (String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password))
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Please enter login details, try again"));
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
                int login = await User.ApiLogin(Email, Password);
                if (login == LoginResponseEnum.LoggedInSuccess)
                {
                    Application.Current.MainPage = new LoggedInAppShell();
                }
                else if (login == LoginResponseEnum.LoggedNotActivated)
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "User not activated.Please log in to your email to verify account"));
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new DefaultPopUp("Error", "Username or Password is incorrect, try again"));
                }
                IsBusy = false;
            }
        }
    }
}
