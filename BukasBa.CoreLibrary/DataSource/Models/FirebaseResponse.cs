using BukasBa.DataSource.Models;
using System.Collections.Generic;

namespace BukasBa.CoreLibrary.DataSource.Models
{
    public class FirebaseResponse : BaseResponse
    {
        public Error error { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<Error1> errors { get; set; }
    }

    public class Error1
    {
        public string message { get; set; }
        public string domain { get; set; }
        public string reason { get; set; }
    }

}