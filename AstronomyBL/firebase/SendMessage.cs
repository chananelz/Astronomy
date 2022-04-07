using AstronomyDP;
using FireSharp;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyBL.firebase
{
    public class SendMessage
    {
        IFirebaseConfig fc = new FireSharp.Config.FirebaseConfig
        {
            AuthSecret = "gPqWPJP1H6zF7bZo1jQf5ax91slhGLmdPSY8fuvt",
            BasePath = "https://fir-astronomy-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public bool sendEncryptedMessage(string myMesssage)
        {
            var data = new EncryptedMessage
            {
               Message = myMesssage,
            };

            client = new FirebaseClient(fc);
            var seret = client.Set("Message/" + "Message1", data);
            return seret.StatusCode.ToString() == "OK";
        }
    }
}
