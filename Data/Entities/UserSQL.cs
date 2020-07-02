using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Data.Entities
{
    public class UserSQL : IUser
    {
         [Key]
        public int Id {get;set;}
        public string Firstname {get;set;}
        public string Lastname {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}

    }
}