
using System.Collections.Generic;
using BitcoinLogger.Data.Entities;

namespace BitcoinLogger.Data.Repositories
{
    public interface IRepository 
    {
          List<IBitcoinSource> GetSources();

          void SaveBitcoinPrice(IBitcoinPrice bitcoinPrice);

          List<IBitcoinPrice> GetBitcoinPrice(int userid);

          IUser GetUser(string username, string password);

          int AddUser(IUser user);

          void UpdateUser(IUser user);

          bool ValidUsername(string username);
    }
}