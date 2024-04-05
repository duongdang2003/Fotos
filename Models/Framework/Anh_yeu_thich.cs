namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Anh_yeu_thich
    {
        [Key]
        public int id_anh_yeu_thich { get; set; }

        public int id_nguoi_dung { get; set; }

        public int? id_anh { get; set; }

        public DateTime? ngay_yeu_thich { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual Nguoi_dung Nguoi_dung { get; set; }
    }
}
