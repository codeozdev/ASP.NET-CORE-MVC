using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_CORE_MVC.Models
{
    public class Kitaplar
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap Adı Boş Geçilemez")]
        public string? KitapAdi { get; set; }

        [Required(ErrorMessage = "Kitap Tanıtım Boş Geçilemez")]
        public string? KitapTanitim { get; set; }

        [Required(ErrorMessage = "Yazar Adı Boş Geçilemez")]
        public string? YazarAdi { get; set; }

        [Required(ErrorMessage = "Yayınevi Adı Boş Geçilemez")]
        public string? YayineviAdi { get; set; }

        [Required(ErrorMessage = "Kitap Fiyatı Boş Geçilemez")]
        public double KitapFiyat { get; set; }

        [ValidateNever]
        public string? KitapResim { get; set; }
    }
}
