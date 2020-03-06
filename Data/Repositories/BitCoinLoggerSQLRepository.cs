using BitcoinLogger.Data.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BitcoinLogger.Data.Repositories
{
    public class BitCoinLoggerSQLRepository :IBitcoinLoggerRepository
    {
         private readonly BitcoinLoggerDB _context;

         public BitCoinLoggerSQLRepository (BitcoinLoggerDB context) {
            _context = context;

        }
        public List<BitcoinSource> GetSources()
        {
            List<BitcoinSource> result = new List<BitcoinSource>();
            result.Add(new BitcoinSource(){SourceId=1, Source="Bitstamp", Uri="https://www.bitstamp.net/api/ticker/"});
            result.Add(new BitcoinSource(){SourceId=2, Source="GDAX", Uri="https://api.gdax.com/products/BTC-USD/ticker"});
            return result;

        }

        public void SaveBitcoinPrice(BitcoinPrice bitcoinPrice)
        {
             _context.BitcoinPrice.Add (bitcoinPrice);
             bitcoinPrice.Timestamp= DateTime.Now;
            _context.SaveChanges ();
        }

        public List<BitcoinPrice> GetBitcoinPrice()
        {
            return _context.BitcoinPrice.ToList();           

        }
    }
}