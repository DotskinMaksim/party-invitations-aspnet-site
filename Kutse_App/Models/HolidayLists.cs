using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kutse_App.Models
{
    public class HolidayLists
    {

        public Dictionary<int, string> Messages { get; set; }
        public Dictionary<int, string> ImageUrls { get; set; }

        public Dictionary<int, string> HolidayDates { get; set; }


        public HolidayLists()
        {
            Messages = new Dictionary<int, string>
            {
                { 1, "Uus aasta" },  { 2, "Sõbrapäev" }, { 3, "Emakeelepäev" },
                { 4, "Munadepühad" }, { 5, "Kevadpühad" }, 
                { 6, "Jaanipäev" },
                { 7, "Suvepuhkus" }, { 8, "Taasiseseisvumispäev" }, { 9, "Kooliaasta algus" },

                { 10, "Halloween" },  { 11, "Isadepäev" }, { 12, "Jõulud" }
            };

            ImageUrls = new Dictionary<int, string>
            {

                { 1, "uusaasta.png" },

                { 2, "sobrapäev.png" },
                { 3, "emakeelepaev.png" },
                { 4, "munadepuhad.png" },

                { 5, "kevadpuhad.png" },
                { 6, "jaanipaev.png" },
                { 7, "suvepuhkus.png" },

                { 8, "taasiseseisvumispaev.png" },
                { 9, "kooliaastaalgus.png" },
                { 10, "halloween.png" },
                { 11, "isadepaev.png" },
                { 12, "joulud.png" }
            };

            HolidayDates  = new Dictionary<int, string>
            {
                { 1, "01.01" }, { 2, "14.02" }, { 3, "14.03" },

                { 4, "04.04" }, { 5, "01.05" },   { 6, "24.06" },
                { 7, "01.07 - 31.08" }, { 8, "20.08" }, { 9, "01.09"   },

                { 10, "31.10" },   { 11, "08.11" }, { 12, "25.12" }
            };
        }
    }
}