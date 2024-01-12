
namespace MiniDukkan.Models
{
    public class EFDukkanRepository : IDukkanRepository
    {
        private MiniDukkanContext context;

        public EFDukkanRepository(MiniDukkanContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Productss => context.Products;
    }
}
