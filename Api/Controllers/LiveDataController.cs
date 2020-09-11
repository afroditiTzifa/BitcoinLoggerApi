using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BitcoinLogger.Data.Entities;
using BitcoinLogger.Core.Models;
using BitcoinLogger.Data.Repositories;
using BitcoinLogger.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace bitcoinlogger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class LiveDataController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        private  IServices _services;
  
        public LiveDataController (IMapper mapper, IRepository repository ) { 
            _mapper= mapper;
            _repository =repository;
        }
        
        [Route("{currrencyPairId}")]
        public async Task<List<BitcoinPriceDTO>> Get (int currrencyPairId) {
            
            var result = new List<BitcoinPriceDTO>();
            var sources = _repository.GetSources();
            var currencyPairs = _repository.GetCurrrencyPairs();
            foreach(var source in sources)
            {
                var uri = sources.Single(x => x.Id == source.Id).Uri;
                var currencyPair = currencyPairs.Single(x=> x.Id == currrencyPairId);
                uri = uri.Replace("{currencyPair}", currencyPair.Description);
                _services= new ServicesFactory().Create(source.Id);
                var liveData = await _services.GetBitcoinPrice(uri);
                var row = _mapper.Map<BitcoinPriceDTO>(liveData);
                row.Source = source.Description;
                row.SourceId = source.Id;
                row.CurrencyPairId = currencyPair.Id;
                row.CurrencyPair = currencyPair.Description;

                result.Add(row);
            }
               
            return result;
            
        }

        
    }
}
