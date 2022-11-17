using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FonProje.Models;

namespace FonProje.Ayar
{
    public class SecurityFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            FonContext db = new FonContext();

            if (HttpContext.Current.Session["Kullanici"] == null)
                HttpContext.Current.Session["Kullanici"] = new Aktif();

            string controlAdi = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionAdi = filterContext.ActionDescriptor.ActionName;
            try
            {


                if (controlAdi == "Admin" && (actionAdi != "Login" && actionAdi != "KullaniciLogin"))
                {
                    if (Projes.Aktif.adminData == null)
                    {
                        filterContext.Result = new RedirectResult("/Admin/Login");
                        return;
                    }
                    Projes.Aktif.adminData = db.Kullanici.Where(x => x.kullaniciID == Projes.Aktif.adminData.kullaniciID).FirstOrDefault();
                }
                base.OnActionExecuting(filterContext);
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("/Home/Hata");
            }

        }
    }

}