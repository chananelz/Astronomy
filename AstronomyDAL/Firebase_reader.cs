using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace AstronomyDAL
{
    internal class Firebase_reader
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "gPqWPJP1H6zF7bZo1jQf5ax91slhGLmdPSY8fuvt",
            BasePath = "https://fir-astronomy-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void reader_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }
    }
}

