using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitcoinLogger.Core.Models
{
    public class LiveDataBitstamp :ILiveData
    {
        [JsonConverter(typeof (UnixDateTimeConverter))]
        [JsonProperty ("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty ("last")]
        public double  LastPrice { get; set; }
        [JsonProperty ("high")]
        public double? HighPrice { get; set; }
        [JsonProperty ("low")]
        public double? LowPrice { get; set; }
        [JsonProperty ("open")]
        public double? OpenPrice { get; set; }
        [JsonProperty ("bid")]
        public double? Bid { get; set; }
        [JsonProperty ("ask")]
        public double? Ask { get; set; }
        [JsonProperty ("volume")]
        public double? Volume { get; set; }
        
    }
}