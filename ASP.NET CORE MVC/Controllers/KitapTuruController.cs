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

        public IActionResult Guncelle(int id)
        {
            KitapTuru kitapTuru = _kitapTuruContext.KitapTurleri.Find(id);
            return View(kitapTuru);
        }


        [HttpPost]
        public IActionResult Guncelle(KitapTuru item)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruContext.KitapTurleri.Update(item);
                _kitapTuruContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Sil(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            KitapTuru kitapTuruId = _kitapTuruContext.KitapTurleri.Find(id);
            return View(kitapTuruId);
        }

        [HttpPost]
        public IActionResult Sil(int id, KitapTuru item)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            KitapTuru kitapTuruId = _kitapTuruContext.KitapTurleri.Find(id);
            if (kitapTuruId == null)
            {
                return NotFound();
            }

            _kitapTuruContext.KitapTurleri.Remove(kitapTuruId);
            _kitapTuruContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
