using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Dtos
{
    public class TownDto
    {
        public int Id { get; set; }

        [Required]
        public int PeopleId { get; set; }

        public PeopleDto People { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Nombre de pueblo no válido.")]
        public string Name { get; set; }
    }
}