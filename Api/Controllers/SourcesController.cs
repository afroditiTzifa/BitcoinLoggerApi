using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BitcoinLogger.Data.Entities;
using BitcoinLogger.Core.Models;
using BitcoinLogger.Data.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace bitcoinlogger.Api.Controllers
{

[ApiController]
[Route("[controller]")]
    public class SourcesController: ControllerBase 
    {
       
       
        private readonly IMapper _mapper;
        private readonly IRepository _repository;
     
  
        public SourcesController (IMapper mapper, IRepository repository ) { 
            _mapper= mapper;
            _repository =repository;
        }
       
        [HttpGet]
        public IActionResult GetSources()
        {
            List<IBitcoinSource> sources = _repository.GetSources();
            return  Ok(_mapper.Map<List<BitcoinSourceDTO>>(sources));

        }
    }
}
