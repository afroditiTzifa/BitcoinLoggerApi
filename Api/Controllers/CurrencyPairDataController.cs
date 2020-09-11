using System.Collections.Generic;
using AutoMapper;
using BitcoinLogger.Core.Models;
using BitcoinLogger.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bitcoinlogger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyPairDataController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

  
        public CurrencyPairDataController (IMapper mapper, IRepository repository ) { 
            _mapper= mapper;
            _repository =repository;
        }
    
         [HttpGet()]
         public List<CurrencyPairDTO> Get()
         {
             var currencyPairs = _repository.GetCurrrencyPairs();
             return _mapper.Map<List<CurrencyPairDTO>>(currencyPairs);
         }

    }
}