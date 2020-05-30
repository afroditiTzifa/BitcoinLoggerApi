using BitcoinLogger.Data.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BitcoinLogger.Data.Repositories
{
    public class SQLRepository: IRepository
                                                    
    {
         private readonly MyDBContext _context;

         public SQLRepository (MyDBContext context) {
            _context = context;

        }
       
        public  List<IBitcoinSource> GetSources()
        {
            return _context.BitcoinSource.ToList<IBitcoinSource>();  

        }
       

        public void SaveBitcoinPrice(IBitcoinPrice bitcoinPrice)
        {
             _context.BitcoinPrice.Add((BitcoinPriceSQL)bitcoinPrice);
            _context.SaveChanges ();
        }

        public List<IBitcoinPrice> GetBitcoinPrice()
        {
            return _context.BitcoinPrice.ToList<IBitcoinPrice>();           
        }

        public int GetUserId(string username, string password)
        {
            return _context.User.Where(x=>x.Username == username && x.UserPassword == password).Select(x=>x.Id).SingleOrDefault();
        }
    }
}