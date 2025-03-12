using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusiCodeWebApp.Models
{
    public class UserRole : Entity
    {
        [Display(Name = "Rol Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Name { get; set; }
        public virtual ICollection<User> users { get; set; }
    }
}