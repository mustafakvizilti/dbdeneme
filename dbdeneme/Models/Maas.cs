using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbdeneme.Models
{
    public class Maas
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Personel")]
        public int PersonelId { get; set; }

        [Required]
        [Display(Name = "Maaş Tutarı")]
        [Range(0, double.MaxValue, ErrorMessage = "Maaş sıfırdan büyük olmalıdır.")]
        public decimal Tutar { get; set; }

        [Required]
        [Display(Name = "Ödeme Tarihi")]
        public DateTime OdemeTarihi { get; set; }

        [ForeignKey("PersonelId")]
        public Personel? Personel { get; set; }
    }
}
