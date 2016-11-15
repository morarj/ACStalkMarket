using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Models
{
    public class Town
    {
        public int Id { get; set; }

        public People People { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public int PeopleId { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Pueblo")]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Nombre de pueblo no válido.")]
        public string Name { get; set; }
    }
}