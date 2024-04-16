namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Danh_gia_album
    {
        [Key]
        public int id_danh_gia { get; set; }

        public int id_nguoi_dung { get; set; }

        public int? id_album { get; set; }

        [StringLength(255)]
        public string binh_luan { get; set; }

        public DateTime? ngay_binh_luan { get; set; }

        public virtual Album Album { get; set; }

        public virtual Nguoi_dung Nguoi_dung { get; set; }
    }
}
