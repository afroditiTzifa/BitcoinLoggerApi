using System;
namespace BitcoinLogger.Core.Models
{
    public interface  ILiveData
    {
        DateTime Timestamp { get; set; }
        double LastPrice { get; set; }
        double? HighPrice { get; set; }
        double? LowPrice { get; set; }
        double? OpenPrice { get; set; }
        double? Bid { get; set; }
        double? Ask { get; set; }
        double? Volume {get;set;}
        
    }
}