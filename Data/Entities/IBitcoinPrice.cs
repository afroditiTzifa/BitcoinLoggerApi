using System;

namespace BitcoinLogger.Data.Entities
{
    public interface  IBitcoinPrice
    {
        public  long Id {get;set;}
        public  int SourceId {get;set;}
        public int UserId {get;set;}
        public int CurrencyPairId {get;set;}
        public  DateTime Timestamp { get; set; }
        public  double LastPrice { get; set; }
        public  double? HighPrice { get; set; }
        public  double? LowPrice { get; set; }
        public  double? OpenPrice { get; set; }
        public  double? Bid { get; set; }
        public  double? Ask { get; set; }
        public  double? Volume { get; set; } 

    }
}