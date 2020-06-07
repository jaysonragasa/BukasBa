using BukasBa.CoreLibrary.DataSource.Interfaces;
using System.Collections.Generic;

namespace BukasBa.DataSource.Models
{
    public class BaseResponse : IBaseResponse
    {
        public bool IsOk { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
    }
}