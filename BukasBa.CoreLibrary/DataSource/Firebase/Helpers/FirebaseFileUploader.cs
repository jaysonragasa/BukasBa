using Firebase.Storage;

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase.Helpers
{
    public class FirebaseFileUploader
    {
        public string Bucket { get; set; } = "";

        public static Lazy<FirebaseFileUploader> Instance { get; set; } = new Lazy<FirebaseFileUploader>();

        public async Task<string> UploadFileAsync(string file, string firebaseToken)
        {
            var stream = File.Open(file, FileMode.Open);
            
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(firebaseToken),
                    ThrowOnCancel = true
                })
                .Child("stores")
                .Child(Path.GetFileName(file)) // file name
                .PutAsync(stream, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Debug.WriteLine($"Progress: {e.Percentage} %");

            try
            {
                return (await task);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}