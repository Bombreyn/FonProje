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
using System.Net;
using System.IO;
using FonProje.App_Start;

namespace FonProje.Controllers
{
    public class HomeController : Controller
    {
        FonContext db = new FonContext();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Projects()
        {
            try
            {
                ViewModel vw = new ViewModel()
                {
                    Proje = db.Proje.ToList(),
                    Kategoris = db.Kategori.ToList()
                };
                return View(vw);

            }
            catch (Exception)
            {
                ViewBag.Message = "Bilinmeyen bir hata meydana geldi";
                return View();
            }
        }

        public ActionResult Project(int id, string projeadi, string kategoriadi)
        {

            try
            {
                var proje = db.Proje.Where(x => x.projeID == id).FirstOrDefault();
                if (seo.Seo.AdresDuzenle(proje.adi) == projeadi && seo.Seo.AdresDuzenle(proje.Kategori.adi) == kategoriadi)
                {
                    return View(proje);
                }
                else
                {
                    ViewBag.Message = "Bilinmeyen bir hata meydana geldi";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                ViewBag.Message = "Bilinmeyen bir hata meydana geldi";
                return View();
            }
        }

        public ActionResult AddProject()
        {
            try
            {
                if (Projes.Aktif.adminData == null)
                {

                    return RedirectToAction("Login", "Admin");
                }
                else
                {


                    ViewModel vw = new ViewModel()
                    {

                        Kategoris = db.Kategori.ToList(),
                        illers = db.iller.ToList(),
                        ilcelers = db.ilceler.ToList()

                    };

                    return View(vw);
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Bilinmeyen bir hata meydana geldi";
                return View();
            }

        }



        [ValidateInput(false)]
        [Authorize]
        [HttpPost]
        public ActionResult ProjeEkle(string adi, string kisa_aciklama, string aciklama, HttpPostedFileBase kapak_resim, IEnumerable<HttpPostedFileBase> galeriresim, decimal hedef, int kategoriID, int ilceID, HttpPostedFileBase resim)
        {

            if (Projes.Aktif != null)
            {

                Proje b = new Proje()
                {

                    adi = adi,
                    kisa_aciklama = kisa_aciklama,
                    aciklama = aciklama,
                    hedef = hedef,
                    kategoriID = kategoriID,
                    ilceID = ilceID,
                    tarih = DateTime.Now,
                    baslangic_tarih = DateTime.Now,
                    bitis_tarih = DateTime.Now,
                    kullaniciID = Projes.Aktif.adminData.kullaniciID
                    
                };
                db.Proje.Add(b);

                if (Request.Files.Count > 0)
                {


                    string projetime = DateTime.Now.ToString("yyyyMMd_Hms_fff");
                    string dosya = Server.MapPath("~/Content/main/img/project_image/" + adi.ToLower().Replace(" ", "") + projetime + "/");
                    Directory.CreateDirectory(dosya);

                    if (galeriresim != null)
                    {
                        foreach (var item in galeriresim)
                        {
                            string dosyaadi1 = Path.GetFileName(item.FileName);
                            string _filename1 = DateTime.Now.ToString("yyyyMMd_Hms_fff") + dosyaadi1;
                            string yol1 = "/Content/main/img/project_image/" + adi.ToLower().Replace(" ", "") + projetime + "/" + _filename1;

                            db.SaveChanges();
                            item.SaveAs(Server.MapPath(yol1));
                            int sonprojeID = db.Proje.Max(x => x.projeID);

                            Resim r = new Resim()
                            {
                                resim1 = yol1,
                                projeID = sonprojeID
                                
                            };
                            db.Resim.Add(r);
                            db.SaveChanges();

                        }
                    }




                    string dosyaadi = Path.GetFileName(kapak_resim.FileName);
                    string _filename = DateTime.Now.ToString("yyyyMMd_Hms_fff") + dosyaadi;
                    string yol = "/Content/main/img/project_image/" + adi.ToLower().Replace(" ", "") + projetime + "/" + _filename;

                    if (yol == "~/Content/main/img/project_image/")
                    {
                        TempData["ResimHata"] = "ResimHata";
                    }
                    else
                    {
                        kapak_resim.SaveAs(Server.MapPath(yol));
                        b.kapak_resim = "/Content/main/img/project_image/" + adi.ToLower().Replace(" ", "") + projetime + "/" + _filename;

                        db.SaveChanges();
                        TempData["TesisEklendi"] = "TesisEklendi";
                        return RedirectToAction("AddProject");
                    }

                }
            }
            else
            {
                return RedirectToAction("Login");
            }

            return RedirectToAction("AddProject");
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}