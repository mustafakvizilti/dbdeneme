using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbdeneme.Models
{
    public class Pozisyon
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pozisyon adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Pozisyon adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Pozisyon Adı")]
        public string Ad { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool AktifMi { get; set; } = true;

        public ICollection<Personel>? Personeller { get; set; }
    }
}
