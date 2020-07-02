
using System.Collections.Generic;
using BitcoinLogger.Data.Entities;

namespace BitcoinLogger.Data.Repositories
{
    public interface IRepository 
    {
          List<IBitcoinSource> GetSources();

          void SaveBitcoinPrice(IBitcoinPrice bitcoinPrice);

          List<IBitcoinPrice> GetBitcoinPrice(int userid);

          int GetUserId(string username, string password);

          void SaveUser(IUser user);
    }
}