﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace MusiCodeWebApp.Models
{
    public class Manager : Entity
    {
        //Ilk Once olusturdugumuz kisim burasi kalitim yaptirdik 1-
        public int ManagerRoleID { get; set; }

        [ForeignKey("ManagerRoleID")]
        public virtual ManagerRole managerRole { get; set; }

        [Display(Name = "Isim")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olabilir")]
        public string Name { get; set; }

        [Display(Name = "Soyisim")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olabilir")]
        public string Surname { get; set; }

        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(maximumLength: 200, MinimumLength = 5, ErrorMessage = "Bu alan en fazla 5-200 karakter arasinda olabilir")]
        public string Mail { get; set; }
        [Display(Name = "Sifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Bu alan en fazla 5-30 karakter arasinda olabilir")]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}