namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Photo()
        {
            Anh_yeu_thich = new HashSet<Anh_yeu_thich>();
            Danh_gia_anh = new HashSet<Danh_gia_anh>();
            Luot_thich_anh = new HashSet<Luot_thich_anh>();
        }

        [Key]
        public int id_photo { get; set; }

        public int id_nguoi_dung { get; set; }

        public int? id_album { get; set; }

        [Required]
        [StringLength(255)]
        public string tieu_de_anh { get; set; }

        [StringLength(255)]
        public string mo_ta_anh { get; set; }

        [Required]
        [StringLength(254)]
        public string url_anh { get; set; }

        public DateTime? ngay_tai_anh_len { get; set; }

        public int? so_luot_danh_gia { get; set; }

        public int? so_luot_thich { get; set; }

        public virtual Album Album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anh_yeu_thich> Anh_yeu_thich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Danh_gia_anh> Danh_gia_anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luot_thich_anh> Luot_thich_anh { get; set; }

        public virtual Nguoi_dung Nguoi_dung { get; set; }
    }
}
