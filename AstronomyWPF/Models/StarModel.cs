using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyWPF.Models
{
    public class StarModel
    {
        public List<Star> Stars { get; set; }
        public String Famely { get; set; }
        
        public StarModel() 
        {
            Stars = new List<Star>
            {
                new Star { Name = "ERETH", ObjectUri = @"C:\AstronomyProject\AstronomyWPF\Images\A.jpg" },
                new Star { Name = "erth2", ObjectUri = @"C:\AstronomyProject\AstronomyWPF\Images\F.jpg" },
                new Star { Name = "san", ObjectUri = @"C:\AstronomyProject\AstronomyWPF\Images\B.png" },
                new Star { Name = "Moon", ObjectUri = @"C:\AstronomyProject\AstronomyWPF\Images\C.png" },
                new Star { Name = "NOGA", ObjectUri = @"C:\AstronomyProject\AstronomyWPF\Images\D.png" }
            };

            Famely = "Kofler";
        }

    }
}
