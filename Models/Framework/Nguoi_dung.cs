namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nguoi_dung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nguoi_dung()
        {
            Albums = new HashSet<Album>();
            Anh_yeu_thich = new HashSet<Anh_yeu_thich>();
            Danh_gia_album = new HashSet<Danh_gia_album>();
            Danh_gia_anh = new HashSet<Danh_gia_anh>();
            Giao_dich = new HashSet<Giao_dich>();
            Giao_dich1 = new HashSet<Giao_dich>();
            Luot_thich_album = new HashSet<Luot_thich_album>();
            Luot_thich_anh = new HashSet<Luot_thich_anh>();
            Photos = new HashSet<Photo>();
        }

        [Key]
        public int id_nguoi_dung { get; set; }

        [Required]
        [StringLength(255)]
        public string ten_nguoi_dung { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(64)]
        public string mat_khau_hashed { get; set; }

        [Required]
        [StringLength(32)]
        public string salt { get; set; }

        [Required]
        [StringLength(255)]
        public string ten_day_du { get; set; }

        [Required]
        [StringLength(20)]
        public string so_dien_thoai { get; set; }

        public DateTime? ngay_dang_ky { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Album> Albums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anh_yeu_thich> Anh_yeu_thich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Danh_gia_album> Danh_gia_album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Danh_gia_anh> Danh_gia_anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giao_dich> Giao_dich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giao_dich> Giao_dich1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luot_thich_album> Luot_thich_album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luot_thich_anh> Luot_thich_anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
