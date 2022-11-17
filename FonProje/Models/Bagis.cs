namespace FonProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bagis
    {
        public int bagisID { get; set; }

        public int? projeID { get; set; }

        public int? kullaniciID { get; set; }

        [Column(TypeName = "text")]
        public string baslik { get; set; }

        [Column(TypeName = "text")]
        public string resim { get; set; }

        [Column(TypeName = "text")]
        public string aciklama { get; set; }

        [Column("bagis", TypeName = "money")]
        public decimal? bagis1 { get; set; }

        public DateTime? tarih { get; set; }

        [Column(TypeName = "text")]
        public string link { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Proje Proje { get; set; }
    }
}
