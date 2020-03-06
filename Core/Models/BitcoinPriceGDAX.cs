using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace BitcoinLogger.Core.Models
{
    public class BitcoinPriceGDAX :IBitcoinPriceDTO
    {
  
        [JsonProperty ("time")]
        public DateTime Timestamp { get; set; }
        [JsonProperty ("price")]
        public double Price { get; set; }
        
    }
}