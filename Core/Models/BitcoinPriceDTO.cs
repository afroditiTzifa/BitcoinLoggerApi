using System;

namespace BitcoinLogger.Core.Models
{
    public class BitcoinPriceDTO 
    {
        public int SourceId {get;set;}
        public string Source {get;set;}
        public int UserId {get;set;}

        public int CurrencyPairId {get;set;}
        public string CurrencyPair {get;set;}

        public DateTime Timestamp { get; set; }
        public double LastPrice { get; set; }
        public double? HighPrice { get; set; }
        public double? LowPrice { get; set; }
        public double? OpenPrice { get; set; }
        public double? Bid { get; set; }
        public double? Ask { get; set; }
        public double? Volume {get;set;}
        
    }
}