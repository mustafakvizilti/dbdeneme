using dbdeneme.Models;
using dbdeneme.Data;
using System.Linq;

namespace dbdeneme
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Pozisyonlar.Any())
            {
                var pozisyonlar = new Pozisyon[]
                {
                    new Pozisyon { Ad = "Yazılım Mühendisi", Aciklama = "Uygulama geliştirme ve bakım işlemlerini yapar." },
                    new Pozisyon { Ad = "İK Uzmanı", Aciklama = "Personel alımı ve insan kaynakları süreçlerini yönetir." },
                    new Pozisyon { Ad = "Finans Uzmanı", Aciklama = "Bütçeleme, muhasebe ve mali analiz yapar." },
                    new Pozisyon { Ad = "Satış Temsilcisi", Aciklama = "Satış operasyonlarını yürütür ve müşteri ilişkilerini yönetir." },
                    new Pozisyon { Ad = "Pazarlama Uzmanı", Aciklama = "Pazar analizleri yapar ve reklam kampanyaları düzenler." },
                    new Pozisyon { Ad = "Ar-Ge Mühendisi", Aciklama = "Yeni ürün ve teknolojilerin geliştirilmesini sağlar." },
                    new Pozisyon { Ad = "Üretim Elemanı", Aciklama = "Üretim hattında görev alır." },
                    new Pozisyon { Ad = "Kalite Kontrol Uzmanı", Aciklama = "Ürün kalitesini test eder ve raporlar." }
                };

                context.Pozisyonlar.AddRange(pozisyonlar);
            }

            if (!context.Departmanlar.Any())
            {
                var departmanlar = new Departman[]
                {
                    new Departman { Ad = "Bilgi Teknolojileri", Aciklama = "Yazılım ve sistem altyapıları yönetimi" },
                    new Departman { Ad = "İnsan Kaynakları", Aciklama = "Personel yönetimi ve işe alım süreçleri" },
                    new Departman { Ad = "Muhasebe", Aciklama = "Finansal işlemler ve raporlar" },
                    new Departman { Ad = "Satış", Aciklama = "Satış operasyonları ve müşteri ilişkileri" },
                    new Departman { Ad = "Pazarlama", Aciklama = "Pazar araştırmaları ve reklam çalışmaları" },
                    new Departman { Ad = "Ar-Ge", Aciklama = "Yeni ürün ve hizmetlerin geliştirilmesi" },
                    new Departman { Ad = "Üretim", Aciklama = "Ürünlerin üretim süreci ve kalite kontrolü" },
                    new Departman { Ad = "Destek Hizmetleri", Aciklama = "İdari ve teknik destek sağlama" }
                };

                context.Departmanlar.AddRange(departmanlar);
            }

            if (!context.Egitimler.Any())
            {
                var egitimler = new Egitim[]
                {
                    new Egitim { Ad = "İşe Alış Eğitimi" },
                    new Egitim { Ad = "İletişim Becerileri" },
                    new Egitim { Ad = "Zaman Yönetimi" },
                    new Egitim { Ad = "Liderlik ve Takım Yönetimi" },
                    new Egitim { Ad = "Müşteri İlişkileri Eğitimi" }
                };

                context.Egitimler.AddRange(egitimler);
            }

         
            context.SaveChanges();
        }
    }
}
