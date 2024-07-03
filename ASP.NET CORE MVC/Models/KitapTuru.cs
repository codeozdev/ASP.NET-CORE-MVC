using System.ComponentModel.DataAnnotations;

namespace ASP.NET_CORE_MVC.Models
{
    public class KitapTuru
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kitap Türü Adı Boş Geçilemez")]
        public string KitapTurAdi { get; set; }
    }
}
