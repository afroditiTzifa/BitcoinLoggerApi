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
    public class HistoryDataController :ControllerBase  
    {
      
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

  
        public HistoryDataController (IMapper mapper, IRepository repository ) { 
            _mapper= mapper;
            _repository =repository;
        }
        

            
        [HttpGet]
        public List<DTO> Get() {
           
            List<IBitcoinPrice> savedData=_repository.GetBitcoinPrice();
            List<IBitcoinSource> sources = _repository.GetSources();
            List<DTO> result = new List<DTO>();
            foreach (IBitcoinPrice row in savedData )
            {
              DTO rowDTO= _mapper.Map<DTO>(row);
              rowDTO.Source = sources.Single(x=>x.Id==row.SourceId).Description;
              result.Add(rowDTO);
            }
            return result;

        }

        [HttpPost]
        public void Post(DTO historyData) {

              IBitcoinPrice bitcoinPrice= _mapper.Map<BitcoinPriceSQL>(historyData);
              _repository.SaveBitcoinPrice(bitcoinPrice);

        }
        
    }
}