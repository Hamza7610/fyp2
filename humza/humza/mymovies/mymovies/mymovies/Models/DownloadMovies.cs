using mymovies.Helper;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mymovies.Models
{
    public class DownloadMovies
    {
        public DownloadMovies(DownloadView obj)
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
        }
        public DownloadMovies()
        {
           
        }
        [PrimaryKey, AutoIncrement]
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
        public string percentage { get; set; }
    }

    public class DownloadMoviesDatabase
    {

        public DownloadMoviesDatabase()
        {

        }
        public static Task CreateTable()
        {
            return Utility.Database.CreateTableAsync<DownloadMovies>();
        }
        public Task DropTable()
        {
            return Utility.Database.DropTableAsync<DownloadMovies>();
        }
        public bool IsTableExists(string tableName)
        {
            try
            {
                var tableInfo = Utility.Database.GetConnection().GetTableInfo(tableName);
                if (tableInfo.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        internal async static Task<int> Remove(DownloadMovies obj)
        {
            return await Utility.Database.DeleteAsync(obj);
        }       

        public static async Task<int> CreateDownloadMovies(DownloadMovies DownloadMovies)
        {
            if (DownloadMovies.ID != 0)
            {
                // Update an existing word.
                return await Utility.Database.UpdateAsync(DownloadMovies);
            }
            else
            {
                // Save a new word.
                return await Utility.Database.InsertAsync(DownloadMovies);
            }
        }
        public static async Task<DownloadMovies> GetDownloadMoviesAsync(int id)
        {
            // Get a specific word.
            return await Utility.Database.Table<DownloadMovies>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public static async Task<DownloadMovies> GetDownloadMoviesAsync(string name)
        {
            // Get a specific word.
            return await Utility.Database.Table<DownloadMovies>()
                            .Where(i => i.name == name)
                            .FirstOrDefaultAsync();
        }
        internal static async Task<DownloadMovies> GetDownloadMoviesAsync(string episode, int season_detail_id, int season_id)
        {
            return await Utility.Database.Table<DownloadMovies>()
                            .Where(i => i.name == episode && i.season_detail_id == season_detail_id && i.season_id == season_id)
                            .FirstOrDefaultAsync();
        }
        public static List<DownloadMovies> GetDownloadMoviesAsync()
        {
            // Get a specific word.
            return Utility.Database.Table<DownloadMovies>()
                            .Where(i => i.isCompleted == false)
                            .ToListAsync().Result;
        }
        public static async Task<List<DownloadMovies>> GetDownloadMoviesListAsync()
        {
            // Get a specific word.
            return await Utility.Database.Table<DownloadMovies>()
                            .ToListAsync();
        }
    }
}
