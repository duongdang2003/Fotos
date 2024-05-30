namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            Photos = new HashSet<Photo>();
            Danh_gia_album = new HashSet<Danh_gia_album>();
            Giao_dich = new HashSet<Giao_dich>();
            Luot_thich_album = new HashSet<Luot_thich_album>();
        }

        [Key]
        public int id_album { get; set; }

        public int so_luong_anh { get; set; }

        public int id_nguoi_dung { get; set; }

        [Required]
        [MaxLength]
        public string tieu_de_album { get; set; }

        [MaxLength]
        public string mo_ta_album { get; set; }

        public DateTime? ngay_tao_album { get; set; }

        public int? so_luot_danh_gia { get; set; }

        public int? so_luot_thich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photos { get; set; }

        public virtual Nguoi_dung Nguoi_dung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Danh_gia_album> Danh_gia_album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giao_dich> Giao_dich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luot_thich_album> Luot_thich_album { get; set; }
    }
}
