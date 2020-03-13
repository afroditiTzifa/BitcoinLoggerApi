using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Data.Entities
{

     public class BitcoinSourceSQL :IBitcoinSource
     {
        [Key]
        public  int Id {get;set;}
        
        public  string Description { get; set; }

        public  string Uri {get;set;}

    }
}
 