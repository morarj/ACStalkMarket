using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Models
{
    public class People
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre")]
        [RegularExpression("")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? BirthDate { get; set; }

        public Gender Gender { get; set; }
        [Required]
        [Display(Name = "Género")]
        public short GenderId { get; set; }
    }
}