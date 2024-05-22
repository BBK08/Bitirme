using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KampveEtkinlikkWebSiteBitirme.Models.Entity;
using System.Web.Mvc;
using System.Web.Security;

namespace KampveEtkinlikkWebSiteBitirme.Controllers
{
    public class LoginController : Controller
    {
        DBCampVeEventEntities db = new DBCampVeEventEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(YeniKayit p)
        {
            var bilgiler = db.YeniKayit.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre==p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail,false);
                Session["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("Index","Misafir");
            }
            else
            {
                 return RedirectToAction("Index");
            }
            
        }
    }
}