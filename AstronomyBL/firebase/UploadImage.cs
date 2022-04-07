using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.IO;
using AstronomyDP;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp;
using Newtonsoft.Json;
using Firebase;
using Firebase.Storage;
using Firebase.Auth;

namespace AstronomyBL.firebase
{
    public class UploadImage
    {
        public async void SendImageToServer(System.IO.FileStream stream)
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
                .Child("Image")
                .Child("random")
                .Child("22.jpg")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, ee) => Console.WriteLine($"Progress: {ee.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            new SendMessage().sendEncryptedMessage(new TaggingImage().getTagFromUrl(downloadUrl));

        }
    }
}
