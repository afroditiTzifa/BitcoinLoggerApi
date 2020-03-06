using System;
namespace BitcoinLogger.Core.Models
{
    public interface  IBitcoinPriceDTO
    {
  
        
        DateTime Timestamp {get;set;}
        
        double Price {get;set;}
        
    }
}