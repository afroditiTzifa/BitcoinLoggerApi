using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BitcoinLogger.Data.Entities;
using BitcoinLogger.Core.Models;
using BitcoinLogger.Data.Repositories;
using BitcoinLogger.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace bitcoinlogger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricesController :ControllerBase  
    {

        
        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        private  IServices _services;
  
        public PricesController (IMapper mapper, IRepository repository ) { 
            _mapper= mapper;
            _repository =repository;
        }
        
        [HttpGet("{sourceId}")]
        public async Task<IBitcoinPriceDTO> GetNewBitcoinPrice (int sourceId) {
            
          
            List<IBitcoinSource> sources = _repository.GetSources();
            string uri = sources.Single(x=>x.Id==sourceId).Uri;
            _services= new ServicesFactory().Create(sourceId);
            IBitcoinPriceDTO result = await _services.GetBitcoinPrice(uri);
            IBitcoinPrice bitcoinPrice = _mapper.Map<BitcoinPriceSQL>(result);
            bitcoinPrice.SourceId = sourceId;
            _repository.SaveBitcoinPrice(bitcoinPrice);
            return result;
            
            
        }

            
        [HttpGet]
        public List<BitcoinPriceDTO> GetFetchedData() {
           
            List<IBitcoinPrice> savedData=_repository.GetBitcoinPrice();
            List<IBitcoinSource> sources = _repository.GetSources();
            List<BitcoinPriceDTO> result = new List<BitcoinPriceDTO>();
            foreach (IBitcoinPrice row in savedData )
            {
              BitcoinPriceDTO rowDTO= _mapper.Map<BitcoinPriceDTO>(row);
              rowDTO.Source = sources.Single(x=>x.Id==row.SourceId).Description;
              result.Add(rowDTO);
            }
            return result;

        }
    }
}