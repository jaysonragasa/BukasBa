using Firebase.Auth;
using Firebase.Storage;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase.Helpers
{
    public class FirebaseFileUploader
    {
        public string ApiKey { get; set; } = null;
        public string Bucket { get; set; } = "";
        public string AuthEmail { get; set; } = null;
        public string AuthPassword { get; set; } = null;

        public static Lazy<FirebaseFileUploader> Instance { get; set; } = new Lazy<FirebaseFileUploader>();

        public async Task<string> UploadFileAsync(string file)
        {
            var stream = File.Open(file, FileMode.Open);

            // of course you can login using other method, not just email+password
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                .Child("eventimages") // folder
                                      //.Child("test") // folder
                .Child(Path.GetFileName(file)) // file name
                .PutAsync(stream, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // cancel the upload
            // cancellation.Cancel();

            try
            {
                // error during upload will be thrown when you await the task
                return await task;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public async Task<string> UploadFileAsync(string file, string firebaseToken)
        {
            var stream = File.Open(file, FileMode.Open);
            
            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(firebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                .Child("stores") // folder
                                      //.Child("test") // folder
                .Child(Path.GetFileName(file)) // file name
                .PutAsync(stream, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            try
            {
                // error during upload will be thrown when you await the task
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