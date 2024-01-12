using System.ComponentModel.DataAnnotations.Schema;

namespace MiniDukkan.Models
{
    public class Product
    {
        public long UrunID{ get; set; }
        public string UrunAd { get; set; }
        public string Aciklama { get; set; }

        [Column(TypeName ="decimal(6,2)")]
        public decimal Fiyat { get; set; }
        public string Kategori { get; set; }
    }
}
