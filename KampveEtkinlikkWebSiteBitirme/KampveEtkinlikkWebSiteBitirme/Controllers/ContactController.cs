//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using KampveEtkinlikkWebSiteBitirme.Models.Entity;

//namespace KampveEtkinlikkWebSiteBitirme.Controllers
//{
//    public class ContactController : Controller
//    {
//        DBCampVeEventEntities bb = new DBCampVeEventEntities();

//        public ActionResult Index()
//        {
//            var bilgiler = bb.İletisim.ToList();
//            return View(bilgiler);
//        }

//        [HttpGet]
//        public PartialViewResult MesajGonder()
//        {
//            return PartialView();
//        }

//        [HttpPost]
//        public ActionResult MesajGonder(tblMesaj mesaj)
//        {
//            if (ModelState.IsValid)
//            {
//                bb.tblMesaj.Add(mesaj);
//                bb.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return PartialView(mesaj);
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using KampveEtkinlikkWebSiteBitirme.Models.Entity;

//namespace KampveEtkinlikkWebSiteBitirme.Controllers
//{
//    public class ContactController : Controller
//    {
//        DBCampVeEventEntities bb = new DBCampVeEventEntities();

//        public ActionResult Index()
//        {
//            var bilgiler = bb.İletisim.ToList();
//            return View(bilgiler);
//        }

//        [HttpGet]
//        public PartialViewResult MesajGonder()
//        {
//            return PartialView();
//        }

//        [HttpPost]
//        public PartialViewResult MesajGonder(tblMesaj mesaj)
//        {
//            var a = HttpContext.Request.Form;
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    bb.tblMesaj.Add(mesaj);
//                    bb.SaveChanges();
//                    return PartialView("Index");
//                }
//                catch (Exception ex)
//                {
//                    // Hata ayıklama için
//                    ModelState.AddModelError("", "Veritabanına kayıt sırasında hata oluştu: " + ex.Message);
//                }
//            }
//            else
//            {
//                // Hata ayıklama için
//                var errors = ModelState.Values.SelectMany(v => v.Errors);
//                foreach (var error in errors)
//                {
//                    Console.WriteLine(error.ErrorMessage);
//                }
//            }

//            return PartialView(mesaj);
//        }
//    }
//}




using System;
using System.Linq;
using System.Web.Mvc;
using KampveEtkinlikkWebSiteBitirme.Models.Entity;

namespace KampveEtkinlikkWebSiteBitirme.Controllers
{
    public class ContactController : Controller
    {
        DBCampVeEventEntities bb = new DBCampVeEventEntities();

        public ActionResult Index()
        {
            var bilgiler = bb.İletisim.ToList();
            return View(bilgiler);
        }

        [HttpGet]
        public PartialViewResult MesajGonder()
        {
            return PartialView(new tblMesaj());
        }

        [HttpPost]
        public ActionResult MesajGonder( tblMesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bb.tblMesaj.Add(mesaj);
                    bb.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Veritabanına kayıt sırasında hata oluştu: " + ex.Message);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return PartialView(mesaj);
        }
    }
}
