using System.Collections.Generic;

namespace BitcoinLogger.Data.Entities
{
    public interface  IBitcoinSource
    {
        public  int Id {get;set;}
        
        public  string Description { get; set; }

        public  string Uri {get;set;}

    }
}