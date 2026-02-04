using Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ByMobil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() {return View();}
        public IActionResult Login(){ return View(); }
        public IActionResult CariArama() { return View(); }
        public IActionResult Anasayfa() { return View(); }
        public IActionResult CariDetay() { return View(); }
        public IActionResult SiparisListe() { return View(); }
        public IActionResult SiparisDuzenle() { return View(); }



    }
}
