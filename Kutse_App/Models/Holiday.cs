using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kutse_App.Models
{
    public class Holiday
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sisesta Nimetus")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Sisesta aeg")]

        public DateTime Date { get; set; }



    }
}