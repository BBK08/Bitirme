using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KampveEtkinlikkWebSiteBitirme.Models.Entity;


namespace KampveEtkinlikkWebSiteBitirme.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DBCampVeEventEntities db = new DBCampVeEventEntities();
       
        public ActionResult Hakkımda()
        {
            var veriler = db.Hakkimda.ToList();
            return View(veriler);
        }
        
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialSocial()
        {
            return PartialView();
        }
    }

}