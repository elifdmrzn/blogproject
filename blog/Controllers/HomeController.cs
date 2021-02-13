using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using blog.Models;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context= context;
        }   

        public IActionResult Index()
        {
            var list = _context.Blog.Take(3).Where(b => b.Yayin).OrderByDescending(x => x.Tarih).ToList();
            foreach(var blog in list)
            {
                blog.Yazar = _context.Yazar.Find(blog.YazarId);
            }
            return View(list);
        }

        public IActionResult About()
        {
           
            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }

        public IActionResult Post(int Id)
        {
            var Blog = _context.Blog.Find(Id);
            Blog.Yazar = _context.Yazar.Find(Blog.YazarId);
            Blog.Resim = "/img/" + Blog.Resim;
            return View(Blog);
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
