using System;

namespace BitcoinLogger.Data.Entities
{
    public interface  IBitcoinPrice
    {
        public  long Id {get;set;}
        public  int SourceId {get;set;}

        public  DateTime Timestamp { get; set; }

        public  double Price { get; set; }
      
    }
}