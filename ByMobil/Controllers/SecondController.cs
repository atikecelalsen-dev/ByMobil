using Microsoft.AspNetCore.Mvc;

namespace BayMobil.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Anasayfa() { return View(); }
        public IActionResult CariArama() { return View(); }
        public IActionResult CariDetay() { return View(); }
        public IActionResult SiparisListe() { return View(); }
        public IActionResult SiparisDuzenle() { return View(); }



    }
}
