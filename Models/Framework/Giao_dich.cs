namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Giao_dich
    {
        [Key]
        public int id_giao_dich { get; set; }

        public int id_nguoi_mua { get; set; }

        public int id_nguoi_ban { get; set; }

        public int id_album { get; set; }

        [Column(TypeName = "money")]
        public decimal gia_tien { get; set; }

        public DateTime? ngay_giao_dich { get; set; }

        public virtual Album Album { get; set; }

        public virtual Nguoi_dung Nguoi_dung { get; set; }

        public virtual Nguoi_dung Nguoi_dung1 { get; set; }
    }
}
