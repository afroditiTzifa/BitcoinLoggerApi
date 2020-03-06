using System.Threading.Tasks;
using BitcoinLogger.Core.Models;


namespace BitcoinLogger.Core.Services {

public interface IBitcoinLoggerServices{
    Task<IBitcoinPriceDTO> GetBitcoinPrice (string uri);
 }


}