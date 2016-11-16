using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Models
{
    public class Week
    {
        public int Id { get; set; }

        public People People { get; set; }
        [Required]
        public int PeopleId { get; set; }

        public Town Town { get; set; }
        public int? TownId { get; set; }

        public WeekValues WeekValues { get; set; }
        [Required]
        public int WeekValuesId { get; set; }

        public WeekPattern WeekPattern { get; set; }
        [Required]
        public byte WeekPatternId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        // Must be monday
        public DateTime StartingDate { get; set; }

        [Required]
        [Range(0, byte.MaxValue)]
        public byte TurnipStartingPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BellsInvestment { get; set; }

        [Required]
        public bool WeekActive { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Profit { get; set; }
    }
}