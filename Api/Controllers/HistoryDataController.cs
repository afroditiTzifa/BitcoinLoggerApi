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
        public List<BitcoinPriceDTO> Get(int userid) {
           
            var savedData=_repository.GetBitcoinPrices(userid);
            return _mapper.Map<List<BitcoinPriceDTO>>(savedData);

        }

        [HttpPost]
        [Route("{userid}")]
        public void Post([FromBody]BitcoinPriceDTO historyData, int userid) {

              var bitcoinPrice = _mapper.Map<BitcoinPriceSQL>(historyData);
              bitcoinPrice.UserId = userid;
              _repository.SaveBitcoinPrice(bitcoinPrice);

        }
        
    }
}