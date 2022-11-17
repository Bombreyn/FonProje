namespace FonProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        public int resimID { get; set; }

        [Column("resim", TypeName = "text")]
        public string resim1 { get; set; }

        public int? projeID { get; set; }

        public virtual Proje Proje { get; set; }
    }
}
