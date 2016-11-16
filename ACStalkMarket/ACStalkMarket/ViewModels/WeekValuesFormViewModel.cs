using ACStalkMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACStalkMarket.ViewModels
{
    public class WeekValuesFormViewModel
    {
        [Required]
        public int WeekId { get; set; }

        [Required]
        public int PeopleId { get; set; }

        [Required]
        public int TownId { get; set; }

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

        WeekValues WeekValues { get; set; }

        public WeekValuesFormViewModel()
        {
            WeekValues.Id = 0;
        }
    }
}