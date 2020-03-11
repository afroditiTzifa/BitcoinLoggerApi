using System.Threading.Tasks;
using BitcoinLogger.Core.Models;


namespace BitcoinLogger.Core.Services {

public interface IServices{
    Task<IBitcoinPriceDTO> GetBitcoinPrice (string uri);
 }


}