using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Models
{
    public class StalkMarketAutomaton
    {
        public DateTime? SellingDate { get; set; }

        public int SellingPrice { get; set; }

        private byte pattern;
        public byte Pattern
        {
            get
            {
                if (pattern == 0 || pattern > 4)
                    return StalkMarketPatterns.Default;

                return pattern;
            }

            set
            {
                pattern = value;
            }
        }

        public DateTime Date { get; set; }

        public int BuyingPrice { get; set; }

        public WeekValues WeekValues { get; set; }

        public StalkMarketAutomaton(DateTime date, int buyingPrice, WeekValues weekValues)
        {
            BuyingPrice = buyingPrice;
            WeekValues = weekValues;
            Date = date;
            Pattern = 0;
            SellingDate = null;
            WeekStart();
        }

        // Monday AM
        private byte WeekStart()
        {
            // Check if its monday morning
            if (Date.DayOfWeek != DayOfWeek.Monday ||
                !Date.ToString("tt", CultureInfo.InvariantCulture).ToUpper().Equals("AM"))
                return 0;

            // Get the retail price of the day
            var retailPrice = GetRetailPrice();

            // Determine the Pattern
            var caseSwitch = (retailPrice >= 100 ||
                retailPrice > BuyingPrice ||
                retailPrice == 0) ? StalkMarketPatterns.Random : StalkMarketPatterns.Decreasing;

            Date = Date.AddHours(12);

            switch (caseSwitch)
            {
                case StalkMarketPatterns.Decreasing:
                    Pattern = StalkMarketPatterns.Decreasing;
                    return State(StalkMarketPatterns.Decreasing);
                case StalkMarketPatterns.Random:
                    Pattern = StalkMarketPatterns.Random;
                    return State(StalkMarketPatterns.Random);
            }

            return 0;
        }

        // State
        private byte State(byte previousPattern)
        {
            // If its Saturday afternoon exit
            if (Date.AddHours(12).DayOfWeek == DayOfWeek.Sunday)
                return 0;

            // Get the next retail price
            var retailNextPrice = GetRetailPrice(Date.AddHours(+12));

            // If the next retail price if 0 thn exit
            if (retailNextPrice == 0)
                return 0;

            var caseSwitch = GetNextStep(previousPattern);
            Date = Date.AddHours(12);

            switch (caseSwitch)
            {
                case StalkMarketPatterns.Decreasing:
                    return State(StalkMarketPatterns.Decreasing);
                case StalkMarketPatterns.Spike:
                    return State(StalkMarketPatterns.Spike);
                case StalkMarketPatterns.Random:
                    return State(StalkMarketPatterns.Random);
            }

            return 0;
        }

        private byte GetNextStep(byte prevPattern)
        {
            // Get the retail price of the day
            var retailPrice = GetRetailPrice();
            // Get the last retail price
            var retailLastPrice = GetRetailPrice(Date.AddHours(-12));

            // Random
            if (prevPattern == StalkMarketPatterns.Random)
            {
                if (retailPrice >= 110 && retailPrice >= BuyingPrice)
                {
                    if (SellingDate == null)
                    {
                        SellingDate = Date;
                        SellingPrice = retailPrice;
                    }

                    if (SellingDate != null && retailPrice > GetRetailPrice((DateTime)SellingDate))
                    {
                        SellingDate = Date;
                        SellingPrice = retailPrice;
                    }
                }

                return StalkMarketPatterns.Random;
            }

            // Decreasing
            if(prevPattern == StalkMarketPatterns.Decreasing)
            {
                if (retailLastPrice > retailPrice)
                {
                    if (Date.AddHours(12).DayOfWeek == DayOfWeek.Friday && 
                            Pattern != StalkMarketPatterns.LowSpike && Pattern != StalkMarketPatterns.HighSpike)
                    {
                        Pattern = StalkMarketPatterns.Decreasing;
                        SellingDate = Date;
                        SellingPrice = retailPrice;
                        return StalkMarketPatterns.Sell;
                    }

                    return StalkMarketPatterns.Decreasing;
                }
                else if (retailPrice > retailLastPrice)
                {
                    return StalkMarketPatterns.Spike;
                }
                else
                {
                    return StalkMarketPatterns.Random;
                }
            }

            // Spike
            if (prevPattern == StalkMarketPatterns.Spike)
            {
                if (Date.AddHours(12).DayOfWeek >= DayOfWeek.Wednesday)
                {
                    if(retailPrice > retailLastPrice &&
                        retailLastPrice > GetRetailPrice(Date.AddHours(-24)) &&
                        GetRetailPrice(Date.AddHours(-24)) > GetRetailPrice(Date.AddHours(-36)))
                    {
                        if (retailPrice >= 300)
                        {
                            Pattern = StalkMarketPatterns.HighSpike;
                            SellingDate = Date;
                            SellingPrice = retailPrice;
                            return StalkMarketPatterns.Sell;
                        }
                    }
                }

                if (Date.DayOfWeek >= DayOfWeek.Wednesday)
                {
                    if (retailPrice > retailLastPrice &&
                        retailLastPrice > GetRetailPrice(Date.AddHours(-24)) &&
                        GetRetailPrice(Date.AddHours(-24)) > GetRetailPrice(Date.AddHours(-36)) &&
                        GetRetailPrice(Date.AddHours(-36)) > GetRetailPrice(Date.AddHours(-48)))
                    {
                        Pattern = StalkMarketPatterns.LowSpike;
                        SellingDate = Date;
                        SellingPrice = retailPrice;
                        return StalkMarketPatterns.Sell;
                    }
                }

                Pattern = StalkMarketPatterns.LowSpike;
                return StalkMarketPatterns.Spike;
            }

            return 0;
        }

        // Get day and time (monAM. monPM) and its value
        private int GetRetailPrice()
        {
            var day = Date.ToString("ddd", CultureInfo.InvariantCulture).ToLower();
            var time = Date.ToString("tt", CultureInfo.InvariantCulture).ToUpper();
            var retailPrice = Convert.ToInt32(
                                    WeekValues.GetType().
                                    GetProperty(string.Concat(day, time)).
                                    GetValue(WeekValues));

            return retailPrice;
        }

        // Get day and time (monAM. monPM) and its value
        private int GetRetailPrice(DateTime date)
        {
            var day = date.ToString("ddd", CultureInfo.InvariantCulture).ToLower();
            var time = date.ToString("tt", CultureInfo.InvariantCulture).ToUpper();
            var retailPrice = Convert.ToInt32(
                                    WeekValues.GetType().
                                    GetProperty(string.Concat(day, time)).
                                    GetValue(WeekValues));

            return retailPrice;
        }
    }
}