using EurecertV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(this ApplicationDbContext context)
        {

            // migration'ları veritabanına uygula
            context.Database.Migrate();

            // Look for any mailsettings record.
            if (context.Cities.Any())
            {
                return;   // DB has been seeded
            }
            // Perform seed operations
            AddCountry(context);
            AddCity(context);
            AddSource(context);
            AddCompanyFunction(context);
            AddApplicationMethod(context);
            AddCertificationResult(context);
            AddMarketingMethod(context);
            AddEducationCategory(context);
            AddServiceField(context);
            AddServices(context);



        }

        public static void AddCountry(ApplicationDbContext context)
        {
            IList<Country> newCountries = new List<Country>();

            newCountries.Add(new Country() { Name = "Türkiye" });
            newCountries.Add(new Country() { Name = "Almanya" });
            newCountries.Add(new Country() { Name = "Diğer" });

            context.Countries.AddRange(newCountries);

            context.SaveChanges();


        }

        public static void AddServiceField(ApplicationDbContext context)
        {
            IList<ServiceField> newServiceFields = new List<ServiceField>();

            newServiceFields.Add(new ServiceField() { Name = "Yapımı Devam Eden Projeler" });
            newServiceFields.Add(new ServiceField() { Name = "Yapımı Tamamlanmış Projeler" });
            newServiceFields.Add(new ServiceField() { Name = "İç Mekan Projeleri" });
            newServiceFields.Add(new ServiceField() { Name = "Dış Mekan Projeleri" });
            newServiceFields.Add(new ServiceField() { Name = "Restorasyon / Yenileme Projeleri" });
            newServiceFields.Add(new ServiceField() { Name = "Hizmet Danışmanlığı" });
            newServiceFields.Add(new ServiceField() { Name = "Ürün Danışmanlığı" });

            context.ServiceFields.AddRange(newServiceFields);

            context.SaveChanges();


        }

        public static void AddServices(ApplicationDbContext context)
        {
            IList<Service> newServices = new List<Service>();

            newServices.Add(new Service() { Name = "Belgelendirme Hizmeti" });
            newServices.Add(new Service() { Name = "Danışmanlık Hizmeti" });
            newServices.Add(new Service() { Name = "Eğitim Hizmeti" });
            

            context.Services.AddRange(newServices);

            context.SaveChanges();


        }

        public static void AddCity(ApplicationDbContext context)
        {
            IList<City> newCities = new List<City>();

            newCities.Add(new City() { CountryId = 1, Name = "01 Adana" });
            newCities.Add(new City() { CountryId = 1, Name = "02 Adıyaman" });
            newCities.Add(new City() { CountryId = 1, Name = "03 Afyon" });
            newCities.Add(new City() { CountryId = 1, Name = "04 Ağrı" });
            newCities.Add(new City() { CountryId = 1, Name = "05 Amasya" });
            newCities.Add(new City() { CountryId = 1, Name = "06 Ankara" });
            newCities.Add(new City() { CountryId = 1, Name = "07 Antalya" });
            newCities.Add(new City() { CountryId = 1, Name = "08 Artvin" });
            newCities.Add(new City() { CountryId = 1, Name = "09 Aydın" });
            newCities.Add(new City() { CountryId = 1, Name = "10 Balıkesir" });
            newCities.Add(new City() { CountryId = 1, Name = "11 Bilecik" });
            newCities.Add(new City() { CountryId = 1, Name = "12 Bingöl" });
            newCities.Add(new City() { CountryId = 1, Name = "13 Bitlis" });
            newCities.Add(new City() { CountryId = 1, Name = "14 Bolu" });
            newCities.Add(new City() { CountryId = 1, Name = "15 Burdur" });
            newCities.Add(new City() { CountryId = 1, Name = "16 Bursa" });
            newCities.Add(new City() { CountryId = 1, Name = "17 Çanakkale" });
            newCities.Add(new City() { CountryId = 1, Name = "18 Çankırı" });
            newCities.Add(new City() { CountryId = 1, Name = "19 Çorum" });
            newCities.Add(new City() { CountryId = 1, Name = "20 Denizli" });
            newCities.Add(new City() { CountryId = 1, Name = "21 Diyarbakır" });
            newCities.Add(new City() { CountryId = 1, Name = "22 Edirne" });
            newCities.Add(new City() { CountryId = 1, Name = "23 Elazığ" });
            newCities.Add(new City() { CountryId = 1, Name = "24 Erzincan" });
            newCities.Add(new City() { CountryId = 1, Name = "25 Erzurum" });
            newCities.Add(new City() { CountryId = 1, Name = "26 Eskişehir" });
            newCities.Add(new City() { CountryId = 1, Name = "27 Gaziantep" });
            newCities.Add(new City() { CountryId = 1, Name = "28 Giresun" });
            newCities.Add(new City() { CountryId = 1, Name = "29 Gümüşhane" });
            newCities.Add(new City() { CountryId = 1, Name = "30 Hakkari" });
            newCities.Add(new City() { CountryId = 1, Name = "31 Hatay" });
            newCities.Add(new City() { CountryId = 1, Name = "32 Isparta" });
            newCities.Add(new City() { CountryId = 1, Name = "33 Mersin" });
            newCities.Add(new City() { CountryId = 1, Name = "34 İstanbul" });
            newCities.Add(new City() { CountryId = 1, Name = "35 İzmir" });
            newCities.Add(new City() { CountryId = 1, Name = "36 Kars" });
            newCities.Add(new City() { CountryId = 1, Name = "37 Kastamonu" });
            newCities.Add(new City() { CountryId = 1, Name = "38 Kayseri" });
            newCities.Add(new City() { CountryId = 1, Name = "39 Kırklareli" });
            newCities.Add(new City() { CountryId = 1, Name = "40 Kırşehir" });
            newCities.Add(new City() { CountryId = 1, Name = "41 Kocaeli" });
            newCities.Add(new City() { CountryId = 1, Name = "42 Konya" });
            newCities.Add(new City() { CountryId = 1, Name = "43 Kütahya" });
            newCities.Add(new City() { CountryId = 1, Name = "44 Malatya" });
            newCities.Add(new City() { CountryId = 1, Name = "45 Manisa" });
            newCities.Add(new City() { CountryId = 1, Name = "46 Kahramanmaraş" });
            newCities.Add(new City() { CountryId = 1, Name = "47 Mardin" });
            newCities.Add(new City() { CountryId = 1, Name = "48 Muğla" });
            newCities.Add(new City() { CountryId = 1, Name = "49 Muş" });
            newCities.Add(new City() { CountryId = 1, Name = "50 Nevşehir" });
            newCities.Add(new City() { CountryId = 1, Name = "51 Niğde" });
            newCities.Add(new City() { CountryId = 1, Name = "52 Ordu" });
            newCities.Add(new City() { CountryId = 1, Name = "53 Rize" });
            newCities.Add(new City() { CountryId = 1, Name = "54 Sakarya" });
            newCities.Add(new City() { CountryId = 1, Name = "55 Samsun" });
            newCities.Add(new City() { CountryId = 1, Name = "56 Siirt" });
            newCities.Add(new City() { CountryId = 1, Name = "57 Sinop" });
            newCities.Add(new City() { CountryId = 1, Name = "58 Sivas" });
            newCities.Add(new City() { CountryId = 1, Name = "59 Tekirdağ" });
            newCities.Add(new City() { CountryId = 1, Name = "60 Tokat" });
            newCities.Add(new City() { CountryId = 1, Name = "61 Trabzon" });
            newCities.Add(new City() { CountryId = 1, Name = "62 Tunceli" });
            newCities.Add(new City() { CountryId = 1, Name = "63 Şanlıurfa" });
            newCities.Add(new City() { CountryId = 1, Name = "64 Uşak" });
            newCities.Add(new City() { CountryId = 1, Name = "65 Van" });
            newCities.Add(new City() { CountryId = 1, Name = "66 Yozgat" });
            newCities.Add(new City() { CountryId = 1, Name = "67 Zonguldak" });
            newCities.Add(new City() { CountryId = 1, Name = "68 Aksaray" });
            newCities.Add(new City() { CountryId = 1, Name = "69 Bayburt" });
            newCities.Add(new City() { CountryId = 1, Name = "70 Karaman" });
            newCities.Add(new City() { CountryId = 1, Name = "71 Kırıkkale" });
            newCities.Add(new City() { CountryId = 1, Name = "72 Batman" });
            newCities.Add(new City() { CountryId = 1, Name = "73 Şırnak" });
            newCities.Add(new City() { CountryId = 1, Name = "74 Bartın" });
            newCities.Add(new City() { CountryId = 1, Name = "75 Ardahan" });
            newCities.Add(new City() { CountryId = 1, Name = "76 Iğdır" });
            newCities.Add(new City() { CountryId = 1, Name = "77 Yalova" });
            newCities.Add(new City() { CountryId = 1, Name = "78 Karabük" });
            newCities.Add(new City() { CountryId = 1, Name = "79 Kilis" });
            newCities.Add(new City() { CountryId = 1, Name = "80 Osmaniye" });
            newCities.Add(new City() { CountryId = 1, Name = "81 Düzce" });

            context.Cities.AddRange(newCities);

            context.SaveChanges();


        }

        public static void AddSource(ApplicationDbContext context)
        {
            IList<Source> newSources = new List<Source>();

            newSources.Add(new Source() { Name = "İnternet" });
            newSources.Add(new Source() { Name = "Referans" });
            newSources.Add(new Source() { Name = "Telefon" });
            newSources.Add(new Source() { Name = "E-Posta" });
            newSources.Add(new Source() { Name = "Diğer" });

            context.Sources.AddRange(newSources);

            context.SaveChanges();


        }



        public static void AddCompanyFunction(ApplicationDbContext context)
        {
            IList<CompanyFunction> newCompanyFunctions = new List<CompanyFunction>();

            newCompanyFunctions.Add(new CompanyFunction() { Code = "A", Name = "Kamu Kuruluşları (A)" });
            newCompanyFunctions.Add(new CompanyFunction() { Code = "B", Name = "Eğitim Yapıları (B)" });
            newCompanyFunctions.Add(new CompanyFunction() { Code = "C", Name = "Sağlık Yapıları (C)" });
            newCompanyFunctions.Add(new CompanyFunction() { Code = "D", Name = "Endüstri Yapıları (D)" });
            newCompanyFunctions.Add(new CompanyFunction() { Code = "E", Name = "Oteller (E)" });
            newCompanyFunctions.Add(new CompanyFunction() { Code = "F", Name = "Ofisler (F)" });
            newCompanyFunctions.Add(new CompanyFunction() { Code = "G", Name = "Kişiye Ait Ev (G)" });
            newCompanyFunctions.Add(new CompanyFunction() { Code = "H", Name = "Karma Kullanım Yapılar (H)" });
            newCompanyFunctions.Add(new CompanyFunction() { Code = "I", Name = "Diğer (I)" });


            context.CompanyFunctions.AddRange(newCompanyFunctions);

            context.SaveChanges();


        }

        public static void AddApplicationMethod(ApplicationDbContext context)
        {
            IList<ApplicationMethod> newApplicationMethods = new List<ApplicationMethod>();

            newApplicationMethods.Add(new ApplicationMethod() { Name = "İnternet" });
            newApplicationMethods.Add(new ApplicationMethod() { Name = "Referans" });
            newApplicationMethods.Add(new ApplicationMethod() { Name = "Telefon" });
            newApplicationMethods.Add(new ApplicationMethod() { Name = "E-Posta" });
            newApplicationMethods.Add(new ApplicationMethod() { Name = "Diğer" });

            context.ApplicationMethods.AddRange(newApplicationMethods);

            context.SaveChanges();


        }

        public static void AddCertificationResult(ApplicationDbContext context)
        {
            IList<CertificationResult> newCertificationResults = new List<CertificationResult>();

            newCertificationResults.Add(new CertificationResult() { Name = "Sertifika almaya hak kazanmıştır" });
            newCertificationResults.Add(new CertificationResult() { Name = "Kurum işlemleri başarı ile tamamlayamadığı için kuruma ek süre verilmiştir" });
            newCertificationResults.Add(new CertificationResult() { Name = "Kurum işlemleri tamamlayamacağını belirttiği için sertifika verilme işlemi iptal edilmiştir" });

            context.CertificationResults.AddRange(newCertificationResults);

            context.SaveChanges();


        }

        public static void AddMarketingMethod(ApplicationDbContext context)
        {
            IList<MarketingMethod> newMarketingMethods = new List<MarketingMethod>();

            newMarketingMethods.Add(new MarketingMethod() { Name = "Mailing" });
            newMarketingMethods.Add(new MarketingMethod() { Name = "Sunum" });
            newMarketingMethods.Add(new MarketingMethod() { Name = "Tanıtım Broşürleri" });
            newMarketingMethods.Add(new MarketingMethod() { Name = "Diğer" });

            context.MarketingMethods.AddRange(newMarketingMethods);

            context.SaveChanges();


        }

        public static void AddEducationCategory(ApplicationDbContext context)
        {
            IList<EducationCategory> newEducationCategories = new List<EducationCategory>();

            newEducationCategories.Add(new EducationCategory() { Name = "Farkındalık Eğitimi" });
            newEducationCategories.Add(new EducationCategory() { Name = "Teknik Ekip Eğitimi" });

            context.EducationCategories.AddRange(newEducationCategories);

            context.SaveChanges();


        }





    }
}
