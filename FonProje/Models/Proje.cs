namespace FonProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proje")]
    public partial class Proje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proje()
        {
            Bagis = new HashSet<Bagis>();
            Resim = new HashSet<Resim>();
            Video = new HashSet<Video>();
        }

        public int projeID { get; set; }

        [Column(TypeName = "text")]
        public string adi { get; set; }

        [Column(TypeName = "text")]
        public string kisa_aciklama { get; set; }

        [Column(TypeName = "text")]
        public string aciklama { get; set; }

        [Column(TypeName = "text")]
        public string kapak_resim { get; set; }

        [Column(TypeName = "money")]
        public decimal? toplanan { get; set; }

        [Column(TypeName = "money")]
        public decimal? hedef { get; set; }

        public DateTime tarih { get; set; }

        public DateTime baslangic_tarih { get; set; }

        public DateTime bitis_tarih { get; set; }

        public bool? aktif { get; set; }

        public int? ilceID { get; set; }

        public int? kategoriID { get; set; }

        public int kullaniciID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bagis> Bagis { get; set; }

        public virtual ilceler ilceler { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Video { get; set; }
    }
}
