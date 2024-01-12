namespace MiniDukkan.Models
{
    public interface IDukkanRepository
    {
        IQueryable<Product>Productss { get; }
    }
}
