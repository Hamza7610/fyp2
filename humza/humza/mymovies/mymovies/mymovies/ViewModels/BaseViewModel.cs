using mymovies.Models;
using mymovies.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace mymovies.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Command LoadCommand { get; set; }
        public Command LoadMoreCommand { get; set; }
        public Command SearchCommand { get; set; }
        private string searchedText;
        public HttpClient Client;

        bool isLoading = false;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }

        bool isBusy = false;
        bool isBusyLoadMore = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        public bool IsBusyLoadMore
        {
            get { return isBusyLoadMore; }
            set { SetProperty(ref isBusyLoadMore, value); }
        }
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public int lastId;
        public bool End { get; set; }
        public int LastId
        {
            get { return lastId; }
            set
            {
                lastId = value; if (value == 0)
                {
                    End = true;
                }
            }
        }

        public string SearchedText { get => searchedText; set => searchedText = value; }

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
