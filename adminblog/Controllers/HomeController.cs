using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using adminblog.Models;
using Microsoft.AspNetCore.Http;
using adminblog.Filter;

namespace adminblog.Controllers
{
    //[UserFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login(string Email, string Sifre)
        {
            var yazar = _context.Yazar.FirstOrDefault(w => w.Email == Email && w.Sifre == Sifre);
            if (yazar == null)
            {
                return RedirectToAction(nameof(Index));
            }

            HttpContext.Session.SetInt32("id", yazar.Id);
            return RedirectToAction(nameof(Kategori));
        }

        public async Task<IActionResult> KategoriEkle(Kategori kategori)
        {
            if (kategori.Id == 0)
            {
                await _context.AddAsync(kategori);

            }
            else
            {
                _context.Update(kategori);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Kategori));
        }

        public IActionResult Kategori()
        {
            List<Kategori> list = _context.Kategori.ToList();
            return View(list);
        }

        public async Task<IActionResult> KategoriSil(int? Id)
        {
            Kategori kategori = await _context.Kategori.FindAsync(Id);
            _context.Remove(kategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Kategori));
        }

        public async Task<IActionResult> KategoriDetay(int Id)
        {
            var kategori = await _context.Kategori.FindAsync(Id);
            return Json(kategori);
        }

        public IActionResult Yazar()
        {
            List<Yazar> list = _context.Yazar.ToList();
            return View(list);
        }

        public async Task<IActionResult> YazarEkle(Yazar yazar)
        {
            if (yazar.Id == 0)
            {
                await _context.AddAsync(yazar);

            }
            else
            {
                _context.Update(yazar);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Yazar));
        }

        public async Task<IActionResult> YazarDetay(int Id)
        {
            var yazar = await _context.Yazar.FindAsync(Id);
            return Json(yazar);
        }

        public async Task<IActionResult> YazarSil(int? Id)
        {
            Yazar yazar = await _context.Yazar.FindAsync(Id);
            _context.Remove(yazar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Yazar));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index()
        {
            return View();
        }

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
