using System;
using System.Collections.Generic;
using System.Text;

namespace mymovies.Models
{
    class Responses
    {
        public int code { get; set; }
        public string user { get; set; }
        public string Message { get; set; }
        public string link { get; set; }
        public string session_id { get; set; }
    }
    class LoginResponseEnum 
    {
        public static int LoggedInSuccess = 2;
        public static int LoggedInAlready = 1;
        public static int LoggedInErrors = 0;
        public static int LoggedNotActivated = -2;

    }
    
}
