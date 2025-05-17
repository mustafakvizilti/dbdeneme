using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace dbdeneme.Models
{
    public class Departman
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Departman adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Departman adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Departman Adı")]
        public string Ad { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool AktifMi { get; set; } = true;

        public ICollection<Personel>? Personeller { get; set; }
    }
}
