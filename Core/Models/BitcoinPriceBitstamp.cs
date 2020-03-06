using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitcoinLogger.Core.Models
{
    public class BitcoinPriceBitstamp :IBitcoinPriceDTO
    {
  [JsonConverter(typeof (UnixDateTimeConverter))]
        [JsonProperty ("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty ("last")]
        public double  Price { get; set; }
        
    }
}