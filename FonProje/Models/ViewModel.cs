using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FonProje.Models;


namespace FonProje.Models
{
    public class ViewModel
    {
        public List<Proje> Proje { get; set; }
        public Proje proje { get; set; }
        public List<Kategori> Kategoris { get; set; }
        public List<iller> illers { get; set; }
        public List<ilceler> ilcelers { get; set; }
        public List<Resim> resims { get; set; }
        public Resim resim { get; set; }

    }
}