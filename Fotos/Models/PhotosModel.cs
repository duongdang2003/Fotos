using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fotos.Models
{
    public class PhotosModel
    {
        public string tieu_de_anh { get; set; }
        public string mo_ta_anh { get; set; }
        public string url_anh { get; set; }
        public string ngay_tai_len { get; set; }
        public int so_luot_danh_gia { get; set; }
        public int so_luot_thich { get; set; }
    }
}