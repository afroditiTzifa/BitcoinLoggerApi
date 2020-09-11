
using System.Collections.Generic;
using BitcoinLogger.Data.Entities;

namespace BitcoinLogger.Data.Repositories
{
    public class MongoRepository : IRepository
    {
        public List<IBitcoinPrice> GetBitcoinPrices(int userid)
        {
            throw new System.NotImplementedException();
        }

        public List<IBitcoinSource> GetSources()
        {
            throw new System.NotImplementedException();
        }

        public void SaveBitcoinPrice(IBitcoinPrice bitcoinPrice)
        {
            throw new System.NotImplementedException();
        }

        public List<ICurrencyPair> GetCurrrencyPairs()
        {
            throw new System.NotImplementedException();
        }

        public IUser GetUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public int AddUser(IUser user)
        {     
            throw new System.NotImplementedException();
        }
        public  void UpdateUser(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidUsername(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}