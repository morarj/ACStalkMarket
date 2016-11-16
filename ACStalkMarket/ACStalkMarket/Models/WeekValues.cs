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
        [Display(Name = "Martes PM")]
        public short tuePM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Miércoles AM")]
        public short wedAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Miércoles PM")]
        public short wedPM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Jueves AM")]
        public short thuAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Jueves PM")]
        public short thuPM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Viernes AM")]
        public short friAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Viernes PM")]
        public short friPM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Sábado AM")]
        public short satAM { get; set; }

        [Range(0, 999)]
        [Display(Name = "Sábado PM")]
        public short satPM { get; set; }

        public void Map(WeekValues weekValues)
        {
            Id = weekValues.Id;
            monAM = weekValues.monAM;
            monPM = weekValues.monPM;
            tueAM = weekValues.tueAM;
            tuePM = weekValues.tuePM;
            wedAM = weekValues.wedAM;
            wedPM = weekValues.wedPM;
            thuAM = weekValues.thuAM;
            thuPM = weekValues.thuPM;
            friAM = weekValues.friAM;
            friPM = weekValues.friPM;
            satAM = weekValues.satAM;
            satPM = weekValues.satPM;
        }
    }
}