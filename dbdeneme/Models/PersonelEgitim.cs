using System;

namespace dbdeneme.Models
{
    public class PersonelEgitim
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public Personel Personel { get; set; }

        public int EgitimId { get; set; }
        public Egitim Egitim { get; set; }

        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string? Aciklama { get; set; }
    }
}
