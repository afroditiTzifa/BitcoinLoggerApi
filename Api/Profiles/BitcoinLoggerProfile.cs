using AutoMapper;
using System.Collections.Generic;

namespace bitcoinlogger.Api.Profiles
{
    public class BitcoinLoggerProfile : Profile
    {
        public BitcoinLoggerProfile()
        {

            CreateMap<BitcoinLogger.Core.Models.DTO, BitcoinLogger.Data.Entities.BitcoinPriceSQL>();
            CreateMap<BitcoinLogger.Data.Entities.BitcoinPriceSQL, BitcoinLogger.Core.Models.DTO>().ForMember(c => c.Source, option => option.Ignore());
        }
        
    }
}