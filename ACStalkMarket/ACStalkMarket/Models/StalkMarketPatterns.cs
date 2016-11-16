using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Models
{
    public static class StalkMarketPatterns
    {
        public const byte Decreasing = 1;
        public const byte LowSpike = 2;
        public const byte HighSpike = 3;
        public const byte Random = 4;
        public const byte Spike = 5;
        public const byte Sell = 6;
    }
}