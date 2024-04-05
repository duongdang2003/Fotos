using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fotos.Models
{
    public class SignInModels
    {
        [Required]
        public String username {  get; set; }
        public String hashed_pass { get; set; }
    }
}