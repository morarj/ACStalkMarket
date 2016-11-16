using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ACStalkMarket.Models
{
    public class WeekValues
    {
        public int Id { get; set; }

        [Range(0, 999)]
        [Display(Name = "Lunes AM")]
        public short monAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Lunes PM")]
        public short monPM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Martes AM")]
        public short tueAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Martes AM")]
        public short tuePM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Miércoles AM")]
        public short wedAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Miércoles AM")]
        public short wedPM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Jueves AM")]
        public short thuAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Jueves AM")]
        public short thuPM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Viernes AM")]
        public short friAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Viernes AM")]
        public short friPM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Sábado AM")]
        public short satAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Sábado AM")]
        public short satPM { get; set; }
    }
}