using BitcoinLogger.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinLogger.Data.Repositories {
    public class MyDBContext : DbContext {
        public DbSet<BitcoinSourceSQL> BitcoinSource { get; set; }
        public DbSet<BitcoinPriceSQL> BitcoinPrice { get; set; }
         public DbSet<UserSQL> User { get; set; }
   
        public MyDBContext (DbContextOptions<MyDBContext> options) : base (options) { }
    }
}