using System.Collections.Generic;

namespace dbdeneme.Models
{
    public class Egitim
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public ICollection<PersonelEgitim> PersonelEgitimler { get; set; }
    }
}
