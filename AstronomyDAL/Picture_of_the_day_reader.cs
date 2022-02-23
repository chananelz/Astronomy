using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Elya Kofler 212853139
// Chananel Zaguri 206275711

namespace AstronomyDAL
{
    public class Picture_of_the_day_reader
    {
        public List<Picture_of_the_day> Pictures { get; set; }

        public Picture_of_the_day_reader()
        {
            Pictures = new List<Picture_of_the_day>
            {
                new Picture_of_the_day{ Url = "https://www.nasa.gov/sites/default/files/styles/full_width_feature/public/thumbnails/image/pia24836_perseverance_selfie_at_rochette_figure_3_croppedcloseup.jpeg", Date = "23/02/2022" ,Classification = "???" },
                //new Picture_of_the_day{ Url = "https://www.nasa.gov/sites/default/files/styles/full_width_feature/public/thumbnails/image/pia24836_perseverance_selfie_at_rochette_figure_3_croppedcloseup.jpeg", Date = "22/02/2022" ,Classification = "???" },
                //new Picture_of_the_day{ Url = "https://www.nasa.gov/sites/default/files/styles/full_width_feature/public/thumbnails/image/pia24836_perseverance_selfie_at_rochette_figure_3_croppedcloseup.jpeg", Date = "21/02/2022" ,Classification = "???" }


            };
        }
    }
}
