using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusiCodeWebApp.Areas.ManagerPanel.Data
{
    public class ManagerLoginViewModel
    {
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Mail alani zorunludur")]
        [StringLength(maximumLength: 200, MinimumLength = 5, ErrorMessage = "Bu alan en fazla 5-200 karakter arasinda olabilir")]
        public string Mail { get; set; }

        [Display(Name = "Sifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Sifre alani zorunludur")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Bu alan en fazla 5-30 karakter arasinda olabilir")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}