using BitcoinLogger.Data.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public List<IBitcoinPrice> GetBitcoinPrices(int userid)
        {
            return _context.BitcoinPrice.Include(u => u.Source).Include(u => u.CurrencyPair)
            .Where(x => x.UserId == userid).ToList<IBitcoinPrice>();           
        }

        public List<ICurrencyPair> GetCurrrencyPairs()
        {
            return _context.CurrencyPair.ToList<ICurrencyPair>();
        }
        public IUser GetUser(string username, string password)
        {
            return _context.User.SingleOrDefault(x=>x.Username == username && x.Password == password);
        }

        public int AddUser(IUser user)
        {     
            _context.User.Add((UserSQL)user);
            _context.SaveChanges();
            return user.Id;
        }

        public  void UpdateUser(IUser user)
        {
            _context.Entry((UserSQL)user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool ValidUsername(string username)
        {
            return _context.User.SingleOrDefault(x=>x.Username == username) == null;
        }
    }
}