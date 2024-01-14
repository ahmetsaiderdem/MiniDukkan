using Microsoft.AspNetCore.Mvc;
using MiniDukkan.Models;
using MiniDukkan.Models.ViewModels;
using System.Diagnostics;

namespace MiniDukkan.Controllers
{
    public class HomeController : Controller
    {

        private IDukkanRepository _repository;
        public int SayfaBoyutu = 3;

        public HomeController(IDukkanRepository repo)
        {
            _repository = repo;
        }



        public ViewResult Index(string kategori, int urunSayfa = 1)
        => View(new UrunlerListesiViewModel
        {
            Urunler = _repository.Productss.Where(u => kategori == null || u.Kategori == kategori).OrderBy(u => u.UrunID).Skip((urunSayfa - 1) * SayfaBoyutu).Take(SayfaBoyutu),
            SayfalamaBilgi = new SayfalamaBilgi
            {
                GuncelSayfa = urunSayfa,
                SayfaBasiGosterilecekUrun = SayfaBoyutu,
                ToplamUrunSayisi = kategori == null ? _repository.Productss.Count() : _repository.Productss.Where(e => e.Kategori == kategori).Count()
            },
            GuncelKategori=kategori
        }
        );



    }
}
