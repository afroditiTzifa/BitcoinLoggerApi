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
    public class UserDataController : ControllerBase
    {
         private readonly IMapper _mapper;
        private readonly IRepository _repository;
  
        public UserDataController (IMapper mapper, IRepository repository ) { 
            _mapper= mapper;
            _repository =repository;
        }

        [Route("{username}/{password}")]
        public int Get(string username, string password)
        {
            return _repository.GetUserId(username, password);
        }
    }

}