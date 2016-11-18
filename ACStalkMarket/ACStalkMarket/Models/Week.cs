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
        [Display(Name = "Patrón")]
        public byte WeekPatternId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        // Must be monday
        public DateTime StartingDate { get; set; }

        [Display(Name = "Fecha de Venta")]
        public DateTime? SellingDate { get; set; }

        [Required]
        [Range(0, 999)]
        [Display(Name = "Precio Máximo de Venta")]
        public int TurnipSellingPrice { get; set; }

        [Required]
        [Range(1, byte.MaxValue)]
        [Display(Name = "Precio Inicial de los Turnips")]
        public byte TurnipStartingPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Inversión")]
        public int BellsInvestment { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public bool WeekActive { get; set; }

        [Required]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Ganancias")]
        public int Profit { get; set; }

        public void Map(Week week)
        {
            Id = week.Id;
            PeopleId = week.PeopleId;
            WeekPatternId = week.WeekPatternId;
            WeekValuesId = week.WeekValuesId;
            BellsInvestment = week.BellsInvestment;
            Profit = week.Profit;
            SellingDate = week.SellingDate;
            StartingDate = week.StartingDate;
            TownId = week.TownId;
            TurnipSellingPrice = week.TurnipSellingPrice;
            TurnipStartingPrice = week.TurnipStartingPrice;
            WeekActive = week.WeekActive;
        }

        public void CalculateProfit()
        {
            Profit = ((BellsInvestment / TurnipStartingPrice) * TurnipSellingPrice) - BellsInvestment;
        }

        public void CalculatePattern(WeekValues weekValues)
        {
            StalkMarketAutomaton automaton = new StalkMarketAutomaton(StartingDate, TurnipStartingPrice, weekValues);
            SellingDate = automaton.SellingDate;
            WeekPatternId = automaton.Pattern;
            TurnipSellingPrice = automaton.SellingPrice;
        }
    }
}