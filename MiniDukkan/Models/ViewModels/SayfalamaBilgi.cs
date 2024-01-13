namespace MiniDukkan.Models.ViewModels
{
    public class SayfalamaBilgi
    {
        public int ToplamUrunSayisi { get; set; }
        public int SayfaBasiGosterilecekUrun { get; set; }
        public int GuncelSayfa { get; set; }
        public int ToplamSayfalar => (int)Math.Ceiling((decimal)ToplamUrunSayisi / SayfaBasiGosterilecekUrun);

    }
}
