using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KampveEtkinlikkWebSiteBitirme.Models.Entity;

namespace KampveEtkinlikkWebSiteBitirme.Controllers
{
    public class KayitController : Controller
    {
        DBCampVeEventEntities db = new DBCampVeEventEntities();
        // GET: Kayit[]
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(YeniKayit p)
        {
            db.YeniKayit.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}