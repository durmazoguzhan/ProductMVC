using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class VisitorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [Range(0, 50, ErrorMessage = "İsim alanı maksimum 50 karakter uzunluğunda olmalıdır.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Yorum alanı zorunludur.")]
        [Range(0, 300, ErrorMessage = "Yorum alanı maksimum 300 karakter uzunluğunda olmalıdır.")]
        public string? Comment { get; set; }

        public DateTime? Created { get; set; }
    }
}
