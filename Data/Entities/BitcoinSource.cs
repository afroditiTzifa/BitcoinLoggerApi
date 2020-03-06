using System.ComponentModel.DataAnnotations;

namespace BitcoinLogger.Data.Entities
{
    public class BitcoinSource
    {
        [Key]
         public int SourceId {get;set;}
        
        public string Source { get; set; }

        public string Uri {get;set;}

    }
}