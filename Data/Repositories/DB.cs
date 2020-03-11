using BitcoinLogger.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinLogger.Data.Repositories {
    public class DB : DbContext {
        public DbSet<BitcoinSource> Source { get; set; }
        public DbSet<BitcoinPrice> BitcoinPrice { get; set; }
   
        public DB (DbContextOptions<DB> options) : base (options) { }
    }
}