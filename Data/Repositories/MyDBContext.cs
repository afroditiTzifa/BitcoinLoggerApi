using BitcoinLogger.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitcoinLogger.Data.Repositories {
    public class MyDBContext : DbContext {
        public DbSet<BitcoinSourceSQL> BitcoinSource { get; set; }
        public DbSet<BitcoinPriceSQL> BitcoinPrice { get; set; }
        public DbSet<UserSQL> User { get; set; }
        public DbSet<CurrencyPairSQL> CurrencyPair { get; set; }
        public MyDBContext (DbContextOptions<MyDBContext> options) : base (options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BitcoinPriceSQL>(entity =>
            {
               
                entity.HasOne(d => d.Source)
                    .WithMany(p => p.BitcoinPrice)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SourceId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BitcoinPrice)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId");

                entity.HasOne(d => d.CurrencyPair)
                    .WithMany(p => p.BitcoinPrice)
                    .HasForeignKey(d => d.CurrencyPairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrencyPairId");
            });

   
            modelBuilder.Entity<UserSQL>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("uidx_pid")
                    .IsUnique();
            });

        }
    }
}