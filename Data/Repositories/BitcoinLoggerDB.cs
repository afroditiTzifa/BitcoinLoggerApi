using BitcoinLogger.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinLogger.Data.Repositories {
    public class BitcoinLoggerDB : DbContext {
        public DbSet<BitcoinSource> Source { get; set; }
        public DbSet<BitcoinPrice> BitcoinPrice { get; set; }
   
        public BitcoinLoggerDB (DbContextOptions<BitcoinLoggerDB> options) : base (options) { }
    }
}