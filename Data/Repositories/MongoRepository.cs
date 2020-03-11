
using System.Collections.Generic;
using BitcoinLogger.Data.Entities;

namespace BitcoinLogger.Data.Repositories
{
    public class MongoRepository : IRepository
    {
        public List<BitcoinPrice> GetBitcoinPrice()
        {
            throw new System.NotImplementedException();
        }

        public List<BitcoinSource> GetSources()
        {
            throw new System.NotImplementedException();
        }

        public void SaveBitcoinPrice(BitcoinPrice bitcoinPrice)
        {
            throw new System.NotImplementedException();
        }
    }
}