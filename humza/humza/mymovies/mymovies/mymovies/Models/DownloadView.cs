using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace mymovies.Models
{
    public class DownloadView
    {
        private string _percentage;
        public DownloadView(DownloadMovies obj)
        {
            this.ID = obj.ID;
            this.name = obj.name;
            this.description = obj.description;
            this.duration = obj.duration;
            this.filename = obj.filename;
            this.image_path = obj.image_path;
            this.isCompleted = obj.isCompleted;
            this.season_detail_id = obj.season_detail_id;
            this.season_id = obj.season_id;
            this.percentage = obj.percentage;
        }

        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string duration { get; set; }
        public string filename { get; set; }
        public byte[] image_path { get; set; }
        public bool isCompleted { get; set; }
        public string url { get; set; }
        public int season_detail_id { get; set; }
        public int season_id { get; set; }
        public string percentage { get { return _percentage + " %"; } set { _percentage = value; } }
        public ImageSource Photo
        {
            get
            {
                if (image_path != null)
                {
                    return ImageSource.FromStream(() => new MemoryStream(image_path));
                }
                return null;

            }
        }

        public bool InProgress { get { return !isCompleted; } }
    }
}
