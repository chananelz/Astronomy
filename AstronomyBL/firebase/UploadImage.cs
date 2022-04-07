using System;
using System.Threading.Tasks;
using Firebase.Storage;
using Firebase.Auth;

namespace AstronomyBL.firebase
{
    public class UploadImage
    {
        static int count = 0;
        public async void SendImageToServer(System.IO.FileStream stream ,string longitude = "" ,string latitude = "")
        {
            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            

            //authentication
            var auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyCYU2lIa1AepwS8PW2vBT3qaxP5bykXlOU"));
            var a = await auth.SignInWithEmailAndPasswordAsync("firebasestorage44@gmail.com", "9ijn8uhb7ygv");


            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage(
                "fir-astronomy.appspot.com",

                 new FirebaseStorageOptions
                 {
                     AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                     ThrowOnCancel = true,
                 })
                .Child("Images")
                .Child("image " + (count++).ToString())
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, ee) => Console.WriteLine($"Progress: {ee.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            new SendMessage().sendEncryptedMessage("I find: " + new TaggingImage().getTagFromUrl(downloadUrl) + " in location longitude:" + longitude + "latitude"+ latitude);

        }
    }
}
