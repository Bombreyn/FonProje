namespace FonProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Video")]
    public partial class Video
    {
        public int videoID { get; set; }

        [Column("video", TypeName = "text")]
        public string video1 { get; set; }

        public int? projeID { get; set; }

        public virtual Proje Proje { get; set; }
    }
}
