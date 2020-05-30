
using System.Collections.Generic;
using BitcoinLogger.Data.Entities;

namespace BitcoinLogger.Data.Repositories
{
    public class MongoRepository : IRepository
    {
        public List<IBitcoinPrice> GetBitcoinPrice()
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

        public int GetUserId(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}