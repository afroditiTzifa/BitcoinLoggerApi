using System;

namespace BitcoinLogger.Core.Models
{
    public class DTO 
    {
        public int SourceId {get;set;}
        public string Source {get;set;}

        public DateTime Timestamp { get; set; }

        public double Price { get; set; }
        public int UserId {get;set;}
        
    }
}