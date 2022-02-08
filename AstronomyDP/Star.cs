using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Elya Kofler 212853139
// Chananel Zaguri 206275711

namespace AstronomyDP
{
    public class Star
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }


        public override string ToString()
        {
            return "Name: " + Name + "   ImageUri: " + ImageUri;
        }

    }


}
