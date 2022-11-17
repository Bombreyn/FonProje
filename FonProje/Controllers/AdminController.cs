using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using FonProje.Models;
using System.Web.Security; //FormsAuthentication kullanmak için
using System.Data.Entity;
using FonProje.App_Start;
using System.Net;
using System.IO;

namespace FonProje.Controllers
{
    public class AdminController : Controller
    {
        FonContext db = new FonContext();

        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // kullanıcılardan veya yöneticilerden gelen isteklere (request) isteklerin doğruluğunu Tokenler aracılığıyla anlayıp ona göre cevap verir
        public ActionResult KullaniciLogin(Kullanici form)
        {
            ViewModel vw = new ViewModel();

            if (!ModelState.IsValid)  // box lar doğru validation şekilde doldurulmasını kontrol ediyor.
            {
                return View("Login", form);
            }


            using (FonContext db = new FonContext())
            {

                var KullaniciVarmi = db.Kullanici.FirstOrDefault(
                    x => x.mail == form.mail && x.sifre == form.sifre); //kullanıcı olup olmadığını kontrol ediyor.

                if (KullaniciVarmi != null)
                {
                    FormsAuthentication.SetAuthCookie(KullaniciVarmi.mail, false); //kullanıcı kayıtlı kalıncaksa true olacak. (cookie)
                    Projes.Aktif.adminData = KullaniciVarmi;
                    return RedirectToAction("Index", "Home");
                }


                ViewBag.Hata = "Mail veya Şifre Hatalı"; //hata mesajı
                return View("Login"); // kullanıcı yok ise geri login sayfasına yönlendiriyor.

            }
        } //login post işlemleri ve kontrol..


        [HttpGet]
        [Authorize]
        public ActionResult Projects()
        {
            try
            {
                ViewModel vw = new ViewModel()
                {

                    Proje = db.Proje.ToList()
                };

                using (FonContext db = new FonContext())
                {

                    var sayi = from i in db.Proje
                                      where i.aktif != true && i.aktif != false
                                      select i;
                    Session["sayi"] = sayi.Count();
                    
                }
                    return View(vw);

                }
            catch (Exception)
            {
                ViewBag.Message = "Bilinmeyen bir hata meydana geldi";
                return View();
            }
        }

        public JsonResult ilcegetir(int p)
        {
            var ilcelerss = (from x in db.ilceler
                             join y in db.iller on x.iller.ilID equals y.ilID
                             where x.iller.ilID == p
                             select new
                             {
                                 Text = x.ilceadi,
                                 Value = x.ilceID.ToString()
                             }).ToList();

            return Json(ilcelerss, JsonRequestBehavior.AllowGet);
        }

    }
}