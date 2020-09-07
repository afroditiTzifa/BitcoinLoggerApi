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
        public IUser Get(string username, string password)
        {
            return _repository.GetUser(username, password);
        }

        [Route("{username}")]
        public bool Get(string username)
        {
            return _repository.ValidUsername(username);
        }

        [HttpPost]
        public int Post([FromBody]UserSQL user)
        {
           return _repository.AddUser(user);
        }

         [HttpPut]
        public void Put([FromBody]UserSQL user)
        {
            _repository.UpdateUser(user);
        }
    }

}