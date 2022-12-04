using mymovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mymovies.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private Movies _movie;
        private Seasons _season;

        public Movies Movie 
        {
            get { return _movie; }
            set { SetProperty(ref _movie,value); }
        }
        public Seasons Season 
        {
            get { return _season; }
            set { SetProperty(ref _season,value); }
        }
        public DetailViewModel(Movies m) { this.Movie = m; }
        public DetailViewModel(Seasons s) { Season = s; }
    }
}
