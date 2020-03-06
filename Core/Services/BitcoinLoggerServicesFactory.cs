namespace BitcoinLogger.Core.Services
{
    public class BitcoinLoggerServicesFactory
    {
        
        public IBitcoinLoggerServices Create(int sourceId)
        {
            if (sourceId==1)
             return new BitcoinLoggerServicesBitmap();
           else 
             return new BitcoinLoggerServicesGDAX();

        }

    }
}