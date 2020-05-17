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
        
        public async Task<List<DTO>> Get () {
            
            List<DTO> result = new List<DTO>();
            List<IBitcoinSource> sources = _repository.GetSources();
            foreach(IBitcoinSource source in sources)
            {
                string uri = sources.Single(x => x.Id == source.Id).Uri;
                _services= new ServicesFactory().Create(source.Id);
                ILiveData liveData = await _services.GetBitcoinPrice(uri);
                DTO row = new DTO()
                {
                    Source=source.Description,
                    SourceId=source.Id,
                    Price = liveData.Price,
                    Timestamp = liveData.Timestamp
                };
              
                result.Add(row);
            }
               
            return result;
            
            
        }

        
    }
}
