using System;
using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Data.Entities
{
    public class BitcoinPriceSQL : IBitcoinPrice
    {
        [Key]
        public  long Id {get;set;}
        public  int SourceId {get;set;}

        public  DateTime Timestamp { get; set; }

        public  double Price { get; set; }
    }




}
