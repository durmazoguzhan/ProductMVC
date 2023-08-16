using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fiyat alanı boş bırakılamaz.")]
        [Range(1, 50000, ErrorMessage = "Fiyat 1 ile 50.000,00₺ arasında olmalıdır.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Stok alanı boş bırakılamaz.")]
        [Range(1, 500, ErrorMessage = "Stok 1 ile 500 arasında olmalıdır.")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Renk alanı boş bırakılamaz.")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Yayınlanma tarihi boş bırakılamaz.")]
        public DateTime? PublishDate { get; set; }

        public bool IsPublish { get; set; }

        [Required(ErrorMessage = "Yayın süresi boş bırakılamaz.")]
        public int? Expire { get; set; }

    }
}
