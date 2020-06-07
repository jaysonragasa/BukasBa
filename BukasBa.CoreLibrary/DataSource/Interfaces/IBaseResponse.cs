using System.Collections.Generic;

namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IBaseResponse
    {
        bool IsOk { get; set; }
        string Message { get; set; }
        Dictionary<string, string> Attributes { get; set; }
    }
}