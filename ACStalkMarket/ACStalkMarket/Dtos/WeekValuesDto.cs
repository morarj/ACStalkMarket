using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ACStalkMarket.Dtos
{
    public class WeekValuesDto
    {
        public int Id { get; set; }

        [Range(0, 999)]
        public short monAM { get; set; }

        [Range(0, 999)]
        public short monPM { get; set; }

        [Range(0, 999)]
        public short tueAM { get; set; }

        [Range(0, 999)]
        public short tuePM { get; set; }

        [Range(0, 999)]
        public short wedAM { get; set; }

        [Range(0, 999)]
        public short wedPM { get; set; }

        [Range(0, 999)]
        public short thuAM { get; set; }

        [Range(0, 999)]
        public short thuPM { get; set; }

        [Range(0, 999)]
        public short friAM { get; set; }

        [Range(0, 999)]
        public short friPM { get; set; }

        [Range(0, 999)]
        public short satAM { get; set; }

        [Range(0, 999)]
        public short satPM { get; set; }
    }
}