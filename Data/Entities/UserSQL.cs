using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Data.Entities
{
    public class UserSQL : IUser
    {
         [Key]
        public int Id {get;set;}
        [Required, MaxLength(50)]
        public string Firstname {get;set;}
        [Required, MaxLength(50)]
        public string Lastname {get;set;}
        [Required, MaxLength(50)]
        public string Username {get;set;}
        [Required, MaxLength(50)]
        public string Password {get;set;}

        public virtual ICollection<BitcoinPriceSQL> BitcoinPrice { get; set; }


    }
}