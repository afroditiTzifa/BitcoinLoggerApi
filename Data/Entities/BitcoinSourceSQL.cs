using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Data.Entities
{

     public class BitcoinSourceSQL :IBitcoinSource
     {
        [Key]
        public  int Id {get;set;}
        [Required, MaxLength(100)]
        public  string Description { get; set; }
        [Required, MaxLength(100)]
        public  string Uri {get;set;}
        
        public virtual ICollection<BitcoinPriceSQL> BitcoinPrice { get; set; }

    }
}
 