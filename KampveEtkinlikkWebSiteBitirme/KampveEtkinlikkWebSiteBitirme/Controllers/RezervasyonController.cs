using KampveEtkinlikkWebSiteBitirme.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KampveEtkinlikkWebSiteBitirme.Controllers
{
    public class RezervasyonController : Controller
    {
        DBCampVeEventEntities db = new DBCampVeEventEntities();

        // GET: Rezervasyon
        [Authorize] //yetkisiz giriş engellendi
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tblRezervasyon p)
        {
            db.tblRezervasyon.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
    }
}