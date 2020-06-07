using BukasBa.CoreLibrary.DataSource.Firebase.Helpers;
using Firebase.Database;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase
{
    public class FirebaseBase
    {
        public FirebaseClient _firebaseClient = new FirebaseClient("https://bukasba-fd8a4.firebaseio.com/", new FirebaseOptions()
        {
            AuthTokenAsyncFactory = () => Task.FromResult("J5ciG9twhvhOODeKnQ4to4wZNXqCq896rUiKOMj3")
        });

        public FirebaseCRUD CRUD { get; set; } = new FirebaseCRUD();

        public FirebaseFileUploader FileUploader { get; set; } = FirebaseFileUploader.Instance.Value;

        public FirebaseBase()
        {
            CRUD.FireClient = this._firebaseClient;
        }
    }
}