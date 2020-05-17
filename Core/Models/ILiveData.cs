using System;
namespace BitcoinLogger.Core.Models
{
    public interface  ILiveData
    {
  

         DateTime Timestamp { get; set; }

         double Price { get; set; }
        
    }
}