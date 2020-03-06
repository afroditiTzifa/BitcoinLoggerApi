using AutoMapper;
using System.Collections.Generic;

namespace bitcoinlogger.Profiles
{
    public class BitcoinLoggerProfile : Profile
    {
        public BitcoinLoggerProfile()
        {

            CreateMap<BitcoinLogger.Data.Entities.BitcoinSource, BitcoinLogger.Core.Models.BitcoinSourceDTO>();
            CreateMap<BitcoinLogger.Core.Models.BitcoinPriceBitstamp, BitcoinLogger.Data.Entities.BitcoinPrice>();
            CreateMap<BitcoinLogger.Core.Models.BitcoinPriceGDAX, BitcoinLogger.Data.Entities.BitcoinPrice>();
            CreateMap<BitcoinLogger.Data.Entities.BitcoinPrice, BitcoinLogger.Core.Models.BitcoinPriceDTO>().ForMember(c => c.Source, option => option.Ignore());
        }
        
    }
}