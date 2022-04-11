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
        static int count = -1;
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
            var seret = client.Set("Message/" + "Message "+ (++count).ToString(), data);

            data.Message = AesOperation.EncryptString(data);
            var encryseret = client.Set("Encryption /" + "Message " + (count).ToString(), data);
            return seret.StatusCode.ToString() == "OK";
        }
    }
}
