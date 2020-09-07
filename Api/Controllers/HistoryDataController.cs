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
        

            
        [HttpGet()]
        [Route("{userid}")]
        public List<DTO> Get(int userid) {
           
            List<IBitcoinPrice> savedData=_repository.GetBitcoinPrice(userid);
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
        [Route("{userid}")]
        public void Post([FromBody]DTO historyData, int userid) {

              IBitcoinPrice bitcoinPrice = _mapper.Map<BitcoinPriceSQL>(historyData);
              bitcoinPrice.UserId = userid;
              _repository.SaveBitcoinPrice(bitcoinPrice);

        }
        
    }
}