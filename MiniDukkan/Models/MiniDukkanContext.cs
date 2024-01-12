using Microsoft.EntityFrameworkCore;

namespace MiniDukkan.Models
{
    public class MiniDukkanContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QU9D9JM; database=MiniDukkanDB; Trusted_Connection=True; TrustServerCertificate=true");
        }

        public MiniDukkanContext(DbContextOptions<MiniDukkanContext> options) : base(options) 
        {
        
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.UrunID); // Id, 'Product' türünün birincil anahtarıdır.
                                                              // Diğer konfigürasyonlar ve ilişkiler eklenebilir.
        }

    }
}
