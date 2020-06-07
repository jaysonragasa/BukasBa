namespace BukasBa.CoreLibrary.Models.Interfaces
{
    public interface IModelAuthDetails
    {
        string Username { get; set; }
        string Password { get; set; }
        bool IsStore { get; set; }
    }
}