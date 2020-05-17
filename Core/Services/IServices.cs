using System.Threading.Tasks;
using BitcoinLogger.Core.Models;


namespace BitcoinLogger.Core.Services {

public interface IServices{
    Task<ILiveData> GetBitcoinPrice (string uri);
 }


}