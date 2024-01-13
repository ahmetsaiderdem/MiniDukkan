using Microsoft.AspNetCore.Mvc;
using MiniDukkan.Models;
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
       

        //public IActionResult Index()
        //{
        //    return View(_repository.Productss);
        //}
        public ViewResult Index(int urunSayfa = 1)=>
        View(_repository.Productss.OrderBy(u=>u.UrunID).Skip((urunSayfa-1)*SayfaBoyutu).Take(SayfaBoyutu));
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
