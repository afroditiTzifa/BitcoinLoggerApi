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

        public List<IBitcoinPrice> GetBitcoinPrice(int userid)
        {
            return _context.BitcoinPrice.Where(x => x.UserId == userid).ToList<IBitcoinPrice>();           
        }

        public IUser GetUser(string username, string password)
        {
            return _context.User.Where(x=>x.Username == username && x.Password == password).SingleOrDefault();
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
            return _context.User.Where(x=>x.Username == username).FirstOrDefault() == null;
        }
    }
}