using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ViewModels
{
    public class PopUpBaseModel : INotifyPropertyChanged
    {

        private string mainTitle;
        private string message;
        public Command PopupCloseCommand { get { return new Command(async () => { await btn_ok_Clicked(); }); } }
        public string Message { get => message; set => SetProperty(ref message, value); }
        public string MainTitle { get => mainTitle; set => SetProperty(ref mainTitle, value); }
        private async Task btn_ok_Clicked()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
