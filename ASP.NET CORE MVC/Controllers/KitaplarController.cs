using ASP.NET_CORE_MVC.Models;
using ASP.NET_MVC.Entility;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_MVC.Controllers
{
    public class KitaplarController : Controller
    {
        private readonly UygulamaDbContext _kitaplarContext;
        public readonly IWebHostEnvironment _webHostEnvironment; // Resim yükleme işlemi için gerekli


        public KitaplarController(UygulamaDbContext kitaplarContext, IWebHostEnvironment webHostEnvironment)
        {
            _kitaplarContext = kitaplarContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Kitaplar> kitaplar = _kitaplarContext.Kitaplar.ToList();
            return View(kitaplar);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Kitaplar item, IFormFile? file) // Resim yükleme işlemi için gerekli parametre
        {

            if (ModelState.IsValid)
            {
                // Resim yükleme işlemi
                string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot path
                string kitapPath = Path.Combine(wwwRootPath, @"img");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(kitapPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    item.KitapResim = @"\img\" + file.FileName;
                }

                _kitaplarContext.Kitaplar.Add(item);
                _kitaplarContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Guncelle(int id)
        {
            Kitaplar kitap = _kitaplarContext.Kitaplar.Find(id);
            return View(kitap);
        }

        [HttpPost]
        public IActionResult Guncelle(Kitaplar item, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                // Resim yükleme işlemi
                string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot path
                string kitapPath = Path.Combine(wwwRootPath, @"img");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(kitapPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    item.KitapResim = @"\img\" + file.FileName;
                }

                _kitaplarContext.Kitaplar.Update(item);
                _kitaplarContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
