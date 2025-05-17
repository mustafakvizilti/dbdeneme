using dbdeneme.Models;

namespace dbdeneme.Controllers
{
    public class PersonelEgitimViewModel
    {
        public int Id { get; set; }
        public Personel Personel { get; set; }
        public int EgitimId { get; set; }
        public string EgitimAd { get; set; }
    }
}
