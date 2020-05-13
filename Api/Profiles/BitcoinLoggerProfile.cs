using AutoMapper;
using System.Collections.Generic;

namespace bitcoinlogger.Api.Profiles
{
    public class BitcoinLoggerProfile : Profile
    {
        public BitcoinLoggerProfile()
        {

            CreateMap<BitcoinLogger.Data.Entities.BitcoinSourceSQL, BitcoinLogger.Core.Models.BitcoinSourceDTO>();
            CreateMap<BitcoinLogger.Core.Models.BitcoinPriceBitstamp, BitcoinLogger.Data.Entities.BitcoinPriceSQL>();
            CreateMap<BitcoinLogger.Core.Models.BitcoinPriceGDAX, BitcoinLogger.Data.Entities.BitcoinPriceSQL>();
            CreateMap<BitcoinLogger.Data.Entities.BitcoinPriceSQL, BitcoinLogger.Core.Models.BitcoinPriceDTO>().ForMember(c => c.Source, option => option.Ignore());
        }
        
    }
}