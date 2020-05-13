namespace BitcoinLogger.Core.Services
{
    public class ServicesFactory
    {
        
        public IServices Create(int sourceId)
        {
            if (sourceId==1)
             return new ServicesBitstamp();
           else 
             return new ServicesGDAX();

        }

    }
}