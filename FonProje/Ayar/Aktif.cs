using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FonProje.Models;

namespace FonProje
{
    public class Projes
    {
        public static Aktif Aktif
        {
            get
            {
                return (Aktif)HttpContext.Current.Session["Kullanici"];
            }
        }
    }
    public class Aktif
    {
        public Kullanici adminData { get; set; }
    }
}