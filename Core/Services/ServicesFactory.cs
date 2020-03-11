namespace BitcoinLogger.Core.Services
{
    public class ServicesFactory
    {
        
        public IServices Create(int sourceId)
        {
            if (sourceId==1)
             return new ServicesBitmap();
           else 
             return new ServicesGDAX();

        }

    }
}