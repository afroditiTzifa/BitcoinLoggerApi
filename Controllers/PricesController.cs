using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BitcoinLogger.Data.Entities;
using BitcoinLogger.Core.Models;
using BitcoinLogger.Data.Repositories;
using BitcoinLogger.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace bitcoinlogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricesController :ControllerBase
    {

        
        private readonly IMapper _mapper;
        private readonly IBitcoinLoggerRepository _repository;
        private  IBitcoinLoggerServices _services;
  
        public PricesController (IMapper mapper, IBitcoinLoggerRepository repository ) { 
            _mapper= mapper;
            _repository =repository;
        }
        
        [HttpGet("{sourceId}")]
        public async Task<IBitcoinPriceDTO> GetNewBitcoinPrice (int sourceId) {
            
            List<BitcoinSource> sources = _repository.GetSources();
            string uri = sources.Single(x=>x.SourceId==sourceId).Uri;
            _services= new BitcoinLoggerServicesFactory().Create(sourceId);
            IBitcoinPriceDTO result = await _services.GetBitcoinPrice(uri);
            BitcoinPrice bitcoinPrice = _mapper.Map<BitcoinPrice>(result);
            bitcoinPrice.SourceId = sourceId;
            _repository.SaveBitcoinPrice(bitcoinPrice);
            return result;
            
        }

            
        [HttpGet]
        public List<BitcoinPriceDTO> GetFetchedData() {
           
            List<BitcoinPrice> savedData=_repository.GetBitcoinPrice();
            List<BitcoinSource> sources = _repository.GetSources();
            List<BitcoinPriceDTO> result = new List<BitcoinPriceDTO>();
            foreach (BitcoinPrice row in savedData )
            {
              BitcoinPriceDTO rowDTO= _mapper.Map<BitcoinPriceDTO>(row);
              rowDTO.Source = sources.Single(x=>x.SourceId==row.SourceId).Source;
              result.Add(rowDTO);
            }
            return result;

        }
    }
}