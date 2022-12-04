using mymovies.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mymovies.Models
{
    public class User : ModelsINotifyProperty
    {
        private string _name;
        
        public int id { get; set; }
        public string name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
            }
        }
        public string email { get; set; }
        public int activated { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        
        public static async Task<int> ApiLogin(string email, string password)
        {
            try
            {
                string session_id = Guid.NewGuid().ToString();
                using (HttpClient Client = new HttpClient())
                {
                    List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                    //Add 'single' parameters
                    bodyProperties.Add(new KeyValuePair<string, string>("email", email));
                    bodyProperties.Add(new KeyValuePair<string, string>("password", password));
                    bodyProperties.Add(new KeyValuePair<string, string>("session_id", session_id));
                    var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.Auth(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Responses LoggedIn = JsonConvert.DeserializeObject<Responses>(result);
                        if (LoggedIn.code == LoginResponseEnum.LoggedInSuccess)
                        {
                            App.Current.Properties.Clear();
                            await App.Current.SavePropertiesAsync();
                            Application.Current.Properties.Add("session_id", LoggedIn.session_id);
                            Application.Current.Properties.Add("user_id", LoggedIn.user);
                            await App.Current.SavePropertiesAsync();
                            ApplicationVariables.LoadApplicationVariables();
                            return LoginResponseEnum.LoggedInSuccess;
                        }
                        else if (LoggedIn.code == LoginResponseEnum.LoggedInAlready)
                        {
                            App.Current.Properties.Clear();
                            await App.Current.SavePropertiesAsync();
                            return LoginResponseEnum.LoggedInAlready;
                        }
                        else if (LoggedIn.code == LoginResponseEnum.LoggedNotActivated)
                        {
                            App.Current.Properties.Clear();
                            await App.Current.SavePropertiesAsync();
                            return LoginResponseEnum.LoggedNotActivated;
                        }

                    }
                    else if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return LoginResponseEnum.LoggedInErrors;
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return LoginResponseEnum.LoggedInErrors;
        }

        internal static async Task<bool> RequestMovie(string requestName)
        {
            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                //Add 'single' parameters
                bodyProperties.Add(new KeyValuePair<string, string>("user_id", ApplicationVariables.User_ID.ToString()));
                bodyProperties.Add(new KeyValuePair<string, string>("movie_name", requestName));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.CreateMovieRequest(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        internal static async Task<bool> Logout()
        {

            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                //Add 'single' parameters
                bodyProperties.Add(new KeyValuePair<string, string>("user_id", ApplicationVariables.User_ID.ToString()));
                bodyProperties.Add(new KeyValuePair<string, string>("session_id", ApplicationVariables.Session_ID));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.Logout(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        public static bool ApiLoginSession()
        {
            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();
                bodyProperties.Add(new KeyValuePair<string, string>("user_id", ApplicationVariables.User_ID.ToString()));
                bodyProperties.Add(new KeyValuePair<string, string>("session_id", ApplicationVariables.Session_ID));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = Client.PostAsync(ApiAddress.AuthSession(), dataContent).Result;
                    string result = response.Content.ReadAsStringAsync().Result;
                    Responses LoggedIn = JsonConvert.DeserializeObject<Responses>(result);
                    if (LoggedIn.code == LoginResponseEnum.LoggedInSuccess)
                    {

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public static async Task<int> CreateUser(string name, string email, string password)
        {

            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                //Add 'single' parameters
                bodyProperties.Add(new KeyValuePair<string, string>("name", name));
                bodyProperties.Add(new KeyValuePair<string, string>("email", email));
                bodyProperties.Add(new KeyValuePair<string, string>("password", password));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.Storeuser(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Responses LoggedIn = JsonConvert.DeserializeObject<Responses>(result);
                        if (LoggedIn.code == Constants.Success)
                        {
                            App.Current.Properties.Clear();
                            await App.Current.SavePropertiesAsync();
                            Application.Current.Properties.Add("session_id", LoggedIn.session_id);
                            Application.Current.Properties.Add("user_id", LoggedIn.user);
                            await App.Current.SavePropertiesAsync();
                            ApplicationVariables.LoadApplicationVariables();
                            return Constants.Success;
                        }
                        else if (LoggedIn.code == Constants.Duplicate)
                        {
                            App.Current.Properties.Clear();
                            await App.Current.SavePropertiesAsync();
                            return Constants.Duplicate;
                        }
                    }


                }
            }
            catch { }
            return Constants.Error;
        }

        public static async Task<bool> ChangePassword(string password, string cNewPassword)
        {
            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                //Add 'single' parameters
                bodyProperties.Add(new KeyValuePair<string, string>("user_id", ApplicationVariables.User_ID.ToString()));
                bodyProperties.Add(new KeyValuePair<string, string>("session_id", ApplicationVariables.Session_ID));
                bodyProperties.Add(new KeyValuePair<string, string>("oldpass", password));
                bodyProperties.Add(new KeyValuePair<string, string>("newpass", cNewPassword));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.ChangePassword(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Responses LoggedIn = JsonConvert.DeserializeObject<Responses>(result);
                        if (LoggedIn.code == Constants.Success)
                        {
                            return true;
                        }                        
                    }
                }
            }
            catch { }
            return false;
        }

        public static async Task<User> GetUser()
        {
            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                //Add 'single' parameters
                bodyProperties.Add(new KeyValuePair<string, string>("user_id", ApplicationVariables.User_ID.ToString()));
                bodyProperties.Add(new KeyValuePair<string, string>("session_id", ApplicationVariables.Session_ID));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.GetUser(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        User LoggedIn = JsonConvert.DeserializeObject<User>(result);
                        return LoggedIn;
                    }
                }
            }
            catch { }
            return null;
        }

        public static async Task<int> ForgetPassword(string email)
        {
            try
            {
                List<KeyValuePair<string, string>> bodyProperties = new List<KeyValuePair<string, string>>();

                //Add 'single' parameters
                bodyProperties.Add(new KeyValuePair<string, string>("email", email));
                var dataContent = new FormUrlEncodedContent(bodyProperties.ToArray());
                using (HttpClient Client = new HttpClient())
                {
                    HttpResponseMessage response = await Client.PostAsync(ApiAddress.ForgetPassword(), dataContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Responses forgetpassword = JsonConvert.DeserializeObject<Responses>(result);
                        return forgetpassword.code;
                    }
                }
            }
            catch { }
            return 0;
        }
    }
}
