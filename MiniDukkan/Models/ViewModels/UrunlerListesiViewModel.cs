namespace MiniDukkan.Models.ViewModels
{
    public class UrunlerListesiViewModel
    {
        public IEnumerable<Product> Urunler { get; set; }

        public SayfalamaBilgi SayfalamaBilgi { get; set; }
        public string GuncelKategori { get; set; }
    }
}
