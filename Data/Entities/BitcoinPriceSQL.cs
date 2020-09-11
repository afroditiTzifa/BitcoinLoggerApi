using System;
using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Data.Entities
{
    public class BitcoinPriceSQL : IBitcoinPrice
    {
        [Key]
        public  long Id {get;set;}
        [Required]
        public  int SourceId {get;set;}
        [Required]
        public int UserId {get;set;}
        [Required]
        public int CurrencyPairId {get;set;}
        [Required]
        public  DateTime Timestamp { get; set; }
        [Required]
        public  double LastPrice { get; set; }
        public  double? HighPrice { get; set; }
        public  double? LowPrice { get; set; }
        public  double? OpenPrice { get; set; }
        public  double? Bid { get; set; }
        public  double? Ask { get; set; }
        public  double? Volume { get; set; } 
        public  virtual BitcoinSourceSQL Source { get; set; }
        public  virtual UserSQL User { get; set; }
        public  virtual CurrencyPairSQL CurrencyPair { get; set; }
    }




}
