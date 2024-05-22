using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KampveEtkinlikkWebSiteBitirme.Models.Entity;

namespace KampveEtkinlikkWebSiteBitirme.Controllers
{
    [Authorize] //Authentication işlemi yapıldı. izinsiz hiç bir yere gidilmez.
    public class MisafirController : Controller
    {
        DBCampVeEventEntities db = new DBCampVeEventEntities();
        // GET: Misafir
        
        public ActionResult Index()
        {
            var misafirmail = (string)Session["Mail"];
            var misafirbilgi = db.YeniKayit.Where(x => x.Mail == misafirmail).FirstOrDefault();
            return View(misafirbilgi);
        }
        public ActionResult Rezervasyonlarim()
        {
            var misafirmail = (string)Session["Mail"];
            //ViewBag.a = misafirmail;                                                                                      //Misafir Bilgileri Taşıma
            var misafirid = db.YeniKayit.Where(x => x.Mail == misafirmail).Select(x => x.ID).FirstOrDefault();
            ViewBag.a = misafirid;
            var degerler = db.tblRezervasyon.Where(x => x.Misafir == misafirid).ToList();
            return View(degerler);
        }
        public ActionResult MisafirBilgiGuncelle(YeniKayit p)
        {
            var misafir = db.YeniKayit.Find(p.ID);
            misafir.AdSoyad = p.AdSoyad;
            misafir.Sifre = p.Sifre;
            misafir.Telefon = p.Telefon;          //Misafir bilgileri güncellenir
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "AnaSayfa");
        }
    }
}