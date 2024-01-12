using Microsoft.EntityFrameworkCore;

namespace MiniDukkan.Models
{
    public class MiniDukkanContext:DbContext
    {
        public MiniDukkanContext(DbContextOptions<MiniDukkanContext> options) : base(options) 
        {
        
        }

        public DbSet<Product> Products { get; set; }
        
    }
}
