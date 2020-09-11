using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BitcoinLogger.Data.Repositories;
using BitcoinLogger.Data.Entities;
using BitcoinLogger.Core.Models;

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
        public UserDTO Get(string username, string password)
        {
            var user = _repository.GetUser(username, password);
            return _mapper.Map<UserDTO>(user);
        }

        [Route("{username}")]
        public bool Get(string username)
        {
            return _repository.ValidUsername(username);
        }

        [HttpPost]
        public int Post([FromBody]UserDTO user)
        {
           var entityUser= _mapper.Map<UserSQL>(user);
           return _repository.AddUser(entityUser);
        }

         [HttpPut]
        public void Put([FromBody]UserDTO user)
        {
            var entityUser= _mapper.Map<UserSQL>(user);
            _repository.UpdateUser(entityUser);
        }
    }

}