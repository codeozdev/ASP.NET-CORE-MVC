using ASP.NET_CORE_MVC.Models;
using ASP.NET_MVC.Entility;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NET_CORE_MVC.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly UygulamaDbContext _kitapTuruContext;

        public KitapTuruController(UygulamaDbContext kitapTuruContext)
        {
            _kitapTuruContext = kitapTuruContext;
        }

        public IActionResult Index()
        {
            List<KitapTuru> kitapTurleri = _kitapTuruContext.KitapTurleri.ToList();
            return View(kitapTurleri);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(KitapTuru item)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruContext.KitapTurleri.Add(item);
                _kitapTuruContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
