using BitcoinLogger.Data.Entities;
using System.Collections.Generic;

namespace BitcoinLogger.Data.Repositories
{
    public interface IRepository
    {
         List<BitcoinSource> GetSources();

         void SaveBitcoinPrice(BitcoinPrice bitcoinPrice);

         List<BitcoinPrice> GetBitcoinPrice();
    }
}