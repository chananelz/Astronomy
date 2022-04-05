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
        public List<PictureOfTheDay> Pictures { get; set; }

        public Picture_of_the_day_reader()
        {
            //Pictures = new List<Picture_of_the_day>
            //{
            //    new Picture_of_the_day{ Url = "https://www.nasa.gov/sites/default/files/styles/full_width_feature/public/thumbnails/image/pia24836_perseverance_selfie_at_rochette_figure_3_croppedcloseup.jpeg", Date = "23/02/2022" ,Classification = "???" },
            //    new Picture_of_the_day{ Url = "https://www.nasa.gov/sites/default/files/styles/image_card_4x3_ratio/public/thumbnails/image/iss066e109851.jpg", Date = "22/02/2022" ,Classification = "???" },
            //    new Picture_of_the_day{ Url = "https://www.nasa.gov/sites/default/files/styles/image_card_4x3_ratio/public/apollo_1_crew_during_water_egress_training_june_1966_1.jpg", Date = "21/02/2022" ,Classification = "???" },
            //    new Picture_of_the_day{ Url = "https://www.nasa.gov/sites/default/files/styles/image_card_4x3_ratio/public/thumbnails/image/hubble_ngc_3568_potw2150a.jpg", Date = "20/02/2022" ,Classification = "???" },
            //    new Picture_of_the_day{ Url = "https://www.nasa.gov/sites/default/files/styles/image_card_4x3_ratio/public/thumbnails/image/epic_1b_20211204075803.png", Date = "19/02/2022" ,Classification = "???" }


            //};

            using (APDBEntities context = new APDBEntities())
            {
                Pictures = (from U in context.PictureOfTheDay
                                select U).ToList();
            }

        }
    }
}
