using dbdeneme.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbdeneme.Models
{
    public class Personel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Departman seçmeniz zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir Departman seçin.")]
        public int DepartmanId { get; set; }

        [ForeignKey("DepartmanId")]
        public Departman? Departman { get; set; }

        [Required(ErrorMessage = "Pozisyon seçmeniz zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir Pozisyon seçin.")]
        public int PozisyonId { get; set; }

        [ForeignKey("PozisyonId")]
        public Pozisyon? Pozisyon { get; set; }

        [Required(ErrorMessage = "Ad gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad gereklidir.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string Soyad { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
        public string? Telefon { get; set; }
        public ICollection<Maas> Maaslar { get; set; } = new List<Maas>();
        public ICollection<PersonelEgitim> PersonelEgitimler { get; set; } = new List<PersonelEgitim>();
        public string AdSoyad => $"{Ad} {Soyad}";


    }
}
