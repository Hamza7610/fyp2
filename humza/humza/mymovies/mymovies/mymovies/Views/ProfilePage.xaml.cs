using mymovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        ProfilePageViewModel vm;
        bool start = true;
        public ProfilePage()
        {
            InitializeComponent();             
            this.BindingContext = vm = new ProfilePageViewModel();
            oldpass.Completed += (object sender, EventArgs e) =>
            {
                newpass.Focus();
            };
            newpass.Completed += (object sender, EventArgs e) =>
            {
                newpass2.Focus();
            };
            newpass2.Completed += (object sender, EventArgs e) =>
            {
                vm.ChangePasswordCommand.Execute(null);
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (start)
            {
                vm.OnAppearing();
                start = false;
            }

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
        async Task TransitionToTitle(object sender, bool animated)
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
                label.TranslationX = 0.0;
                label.TranslationY = -30;
                label.FontSize = 14;
            }
        }
        async Task TransitionToPlaceholder(object sender, bool animated)
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
        private async void oldPassword_Unfocused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToPlaceholder(oldpasslbl, true);
            }
        }

        private async void oldPassword_Focused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToTitle(oldpasslbl, true);
            }
        }

        private async void newPassword_Unfocused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToPlaceholder(newpasstitle, true);
            }
        }

        private async void newPassword_Focused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToTitle(newpasstitle, true);
            }
        }

        private async void newpass2Password_Unfocused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToPlaceholder(newpass2title, true);
            }
        }

        private async void newpass2Password_Focused(object sender, FocusEventArgs e)
        {
            var textfield = (Xamarin.Forms.Entry)sender;
            if (string.IsNullOrEmpty(textfield.Text))
            {
                await TransitionToTitle(newpass2title, true);
            }
        }

        private void OldpassPasswordTitle_Tapped(object sender, EventArgs e)
        {
            var textfield = (Xamarin.Forms.Label)sender;
            oldpass.Focus();
        }
        private void NewpassPasswordTitle_Tapped(object sender, EventArgs e)
        {
            var textfield = (Xamarin.Forms.Label)sender;
            newpass.Focus();
        }
        private void Newpass2PasswordTitle_Tapped(object sender, EventArgs e)
        {
            var textfield = (Xamarin.Forms.Label)sender;
            newpass2.Focus();
        }
    }
}