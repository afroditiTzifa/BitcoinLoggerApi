using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Data.Entities
{
    public class CurrencyPairSQL :ICurrencyPair
    {
        [Key]         
        public int Id {get;set;}
        [Required, MaxLength(50)]
        public string Description {get;set;}

        public virtual ICollection<BitcoinPriceSQL> BitcoinPrice { get; set; }
    }
}
