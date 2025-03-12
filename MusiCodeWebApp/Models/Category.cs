using System.ComponentModel.DataAnnotations;

namespace MusiCodeWebApp.Models
{
    public class Category : Entity
    {
        public Category() { IsDeleted = false; IsActive = true; }
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır")]
        public string Name { get; set; }


        [StringLength(maximumLength: 500, ErrorMessage = "Bu alan en fazla 500 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }


        [Display(Name = "True")]
        public bool IsActive { get; set; }


    }
}