using System;

namespace BitcoinLogger.Core.Models
{
    public class UserDTO 
    {
        public int Id {get;set;}
        public string Firstname {get;set;}
        public string Lastname {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}
    }
}