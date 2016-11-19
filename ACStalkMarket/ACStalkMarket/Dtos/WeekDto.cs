using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Dtos
{
    public class WeekDto
    {
        public int Id { get; set; }

        [Required]
        public int PeopleId { get; set; }

        public PeopleDto People { get; set; }

        public int? TownId { get; set; }

        public TownDto Town { get; set; }

        [Required]
        public int WeekValuesId { get; set; }

        public WeekValuesDto WeekValues { get; set; }

        [Required]
        public byte WeekPatternId { get; set; }

        public WeekPatternDto WeekPattern { get; set; }

        [Required]
        [DataType(DataType.Date)]
        // Must be monday
        public DateTime StartingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SellingDate { get; set; }

        [Required]
        [Range(0, 999)]
        public int TurnipSellingPrice { get; set; }

        [Required]
        [Range(1, byte.MaxValue)]
        public byte TurnipStartingPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BellsInvestment { get; set; }

        [Required]
        public bool WeekActive { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public int Profit { get; set; }
    }
}