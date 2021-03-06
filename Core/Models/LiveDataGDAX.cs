using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace BitcoinLogger.Core.Models
{
    public class LiveDataGDAX :ILiveData
    {
  
        [JsonProperty ("time")]
        public DateTime Timestamp { get; set; }
        [JsonProperty ("price")]
        public double LastPrice { get; set; }

        public double? HighPrice { get; set; }
        public double? LowPrice { get; set; }
        public double? OpenPrice { get; set; }

        [JsonProperty ("bid")]
        public double? Bid { get; set; }
        [JsonProperty ("ask")]
        public double? Ask { get; set; }
        [JsonProperty ("volume")]
        public double? Volume { get; set; }
        
    }
}