using System;

namespace BitcoinLogger.Core.Models
{
    public class BitcoinPriceDTO :IBitcoinPriceDTO
    {
        public int SourceId {get;set;}
        public string Source {get;set;}

        public DateTime Timestamp { get; set; }

        public double Price { get; set; }
        
    }
}