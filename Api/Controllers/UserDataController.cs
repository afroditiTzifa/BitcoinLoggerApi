using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BitcoinLogger.Data.Repositories;
using BitcoinLogger.Data.Entities;

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

        [HttpPost]
        public void Post([FromBody]UserSQL user)
        {
            _repository.SaveUser(user);
        }
    }

}