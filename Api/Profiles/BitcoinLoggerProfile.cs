using AutoMapper;
using System.Collections.Generic;

namespace bitcoinlogger.Api.Profiles
{
    public class BitcoinLoggerProfile : Profile
    {
        public BitcoinLoggerProfile()
        {

            CreateMap<BitcoinLogger.Core.Models.BitcoinPriceDTO, BitcoinLogger.Data.Entities.BitcoinPriceSQL>()
            .ForMember(d => d.Source, opt => opt.Ignore())
            .ForMember(d => d.CurrencyPair, opt => opt.Ignore());
            CreateMap<BitcoinLogger.Data.Entities.BitcoinPriceSQL, BitcoinLogger.Core.Models.BitcoinPriceDTO>()
            .ForMember(d => d.Source, m => m.MapFrom(s => s.Source.Description))
            .ForMember(d => d.CurrencyPair, m => m.MapFrom(s => s.CurrencyPair.Description));
            CreateMap<BitcoinLogger.Core.Models.LiveDataBitstamp, BitcoinLogger.Core.Models.BitcoinPriceDTO>();
            CreateMap<BitcoinLogger.Core.Models.LiveDataGDAX, BitcoinLogger.Core.Models.BitcoinPriceDTO>();
            CreateMap<BitcoinLogger.Core.Models.UserDTO, BitcoinLogger.Data.Entities.UserSQL>();
            CreateMap<BitcoinLogger.Data.Entities.UserSQL, BitcoinLogger.Core.Models.UserDTO>();
            CreateMap<BitcoinLogger.Data.Entities.CurrencyPairSQL, BitcoinLogger.Core.Models.CurrencyPairDTO>();
            
          
        }
        
    }
}