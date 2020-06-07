using BukasBa.CoreLibrary.Models.Interfaces;

namespace BukasBa.CoreLibrary.Models.DTO
{
    public class DTO_AuthDetails : IModelAuthDetails
    {
        public string Username { get; set; } = null;
        public string Password { get; set; } = null;
        public bool IsStore { get; set; } = false;
    }
}