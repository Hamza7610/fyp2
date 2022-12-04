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
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            ForgetPasswordViewModel vm = new ForgetPasswordViewModel();
            InitializeComponent();
            this.BindingContext = vm;
            Email.Completed += (object sender, EventArgs e) =>
            {
                vm.ForgetPasswordCommand.Execute(null);
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
                label.TranslationX = 0;
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

        private void UsernameTitle_Tapped(object sender, EventArgs e)
        {
            Email.Focus();
        }
    }
}