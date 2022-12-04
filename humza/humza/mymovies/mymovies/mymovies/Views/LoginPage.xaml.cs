using mymovies.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            LoginViewModel vm = new LoginViewModel();
            this.BindingContext = vm;
            InitializeComponent();
            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.LoginCommand.Execute(null);
            };
        }

        private async void EntryField_Unfocused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToPlaceholder(EmailTitle, true);
            }
        }

        private async void EntryField_Focused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToTitle(EmailTitle, true);
            }
        }
        async Task TransitionToTitle(object sender,bool animated)
        {
            var label = (Xamarin.Forms.Label)sender;
            if (animated)
            {
                
                var t1 = label.TranslateTo(0, -10, 100);
                label.FontSize = 12;
                await Task.WhenAll(t1);
            }
            else
            {
                label.TranslationX = 0;
                label.TranslationY = -30;
                label.FontSize = 14;
            }
        }
        async Task TransitionToPlaceholder(object sender,bool animated)
        {
            var label = (Xamarin.Forms.Label)sender;
            if (animated)
            {
                var t1 = label.TranslateTo(0, 0, 100);
                label.FontSize = 18;
                await Task.WhenAll(t1);
            }
            else
            {
                label.TranslationX = 10;
                label.TranslationY = 0;
                label.FontSize = 40;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Email.Focus();
        }

        private async void Password_Unfocused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToPlaceholder(PasswordTitle, true);
            }
        }

        private async void Password_Focused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToTitle(PasswordTitle, true);
            }
        }

        private  void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Password.Focus();
        }
    }
}