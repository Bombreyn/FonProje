namespace FonProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Bagis = new HashSet<Bagis>();
            Proje = new HashSet<Proje>();
        }

        public int kullaniciID { get; set; }

        [StringLength(500)]
        public string adi { get; set; }

        [StringLength(500)]
        public string soyadi { get; set; }

        [StringLength(500)]
        public string sifre { get; set; }

        [StringLength(500)]
        public string mail { get; set; }

        public DateTime? dogum_tarihi { get; set; }

        [StringLength(50)]
        public string telefon { get; set; }

        public int? yetkiID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bagis> Bagis { get; set; }

        public virtual Yetki Yetki { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proje> Proje { get; set; }
    }
}
