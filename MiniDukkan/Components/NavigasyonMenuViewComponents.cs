using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiniDukkan.Models;

namespace MiniDukkan.Components
{
    public class NavigasyonMenuViewComponents:ViewComponent
    {
        private IDukkanRepository repository;
        public NavigasyonMenuViewComponents(IDukkanRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SecilenKategori = RouteData?.Values["kategori"];
            
            return View(repository.Productss.Select(x => x.Kategori).Distinct().OrderBy(x=>x));
        }
    }
}
