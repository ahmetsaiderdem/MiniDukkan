using Microsoft.EntityFrameworkCore;

namespace MiniDukkan.Models
{
    public static class HamVeri
    {
        public static void VeriDoldur(IApplicationBuilder app)
        {
            MiniDukkanContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MiniDukkanContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(

                    new Product
                    {
                        UrunAd = "Çıngırak",
                        Aciklama = "Bebek çıngırağı boncuklu",
                        Kategori = "Bebek Oyuncakları",
                        Fiyat = 15
                    },

                    new Product
                    {
                        UrunAd = "Oyun Halısı",
                        Aciklama = "Resimli oyun halısı",
                        Kategori = "Bebek Oyuncakları",
                        Fiyat = 150
                    },

                   new Product
                   {
                       UrunAd = "Barbie bebek",
                       Aciklama = "Barbie elbiseli oyuncak",
                       Kategori = "Kız Oyuncakları",
                       Fiyat = 60
                   },

                   new Product
                   {
                       UrunAd = "Mutfak Seti",
                       Aciklama = "Plastik mutfak eşyaları",
                       Kategori = "Kız Oyuncakları",
                       Fiyat = 120
                   },

                   new Product
                   {
                       UrunAd = "Barbie ev",
                       Aciklama = "Portatik barbie evi",
                       Kategori = "Kız Oyuncakları",
                       Fiyat = 200
                   },

                   new Product
                   {
                       UrunAd = "Oyuncak Traktör",
                       Aciklama = "Plastik traktör",
                       Kategori = "Erkek Oyuncakları",
                       Fiyat = 250
                   },

                   new Product
                   {
                       UrunAd = "Tabanca",
                       Aciklama = "Oyuncak merimili tabanca",
                       Kategori = "Erkek Oyuncakları",
                       Fiyat = 100
                   },

                   new Product
                   {
                       UrunAd = "Akülü Jip",
                       Aciklama = "Akülü volvo jip",
                       Kategori = "Genel Oyuncakları",
                       Fiyat = 20000
                   }

                    );
                context.SaveChanges();
            }
        }
    }
}
