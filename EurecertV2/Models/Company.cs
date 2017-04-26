using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class Company
    {
        public Company()
        {
            VisitCount = 0;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        public int Id { get; set; }
        [Required (ErrorMessage ="Kurum ad alanı boş bırakılamaz.")]
        [StringLength(200)]
        [Display(Name = "Kurum Adı")]
        public string Name { get; set; }
        [Display(Name = "Kurum İşlevi")]
        public int? CompanyFunctionId { get; set; }
        [ForeignKey("CompanyFunctionId")]
        [Display(Name = "Kurum İşlevi")]
        public virtual CompanyFunction CompanyFunction { get; set; }
        [Display(Name = "Ülke")]
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        [Display(Name = "Ülke")]
        public virtual Country Country { get; set; }
        [Display(Name = "Şehir")]
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        [Display(Name = "Şehir")]
        public virtual City City { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [StringLength(200)]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [StringLength(200)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [StringLength(200)]
        [Display(Name = "Web Sitesi")]
        public string Website { get; set; }
        [Display(Name = "Haberdar Olma Şekli")]
        public int? SourceId { get; set; }
        [ForeignKey("SourceId")]
        [Display(Name = "Haberdar Olma Şekli")]
        public virtual Source Source { get; set; }
        [Display(Name = "Satış Temsilcisi")]
        public string SalesPersonId { get; set; }
        [ForeignKey("SalesPersonId")]
        [Display(Name = "Satış Temsilcisi")]
        public virtual ApplicationUser SalesPerson { get; set; }
        [Display(Name = "Teklif Ön Bilgileri")]
        [DataType(DataType.MultilineText)]
        public string ProposalAbstract { get; set; }
        [StringLength(200)]
        [Display(Name = "Teklif Dosyası")]
        public string ProposalFile { get; set; }
        [Display(Name = "Teklif Dönüşü")]
        [DataType(DataType.MultilineText)]
        public string ProposalResult { get; set; }
        [Display(Name = "Peşinat")]
        [DataType(DataType.Currency)]
        public decimal? DownPayment { get; set; }
        [Display(Name = "Toplam Alacak")]
        [DataType(DataType.Currency)]
        public decimal? TotalAmount { get; set; }
        [Display(Name = "Verilen Hizmetler")]
        public virtual ICollection<CompanyService> CompanyServices { get; set; }
        [Display(Name = "Kurumun Talepleri")]
        [DataType(DataType.MultilineText)]
        public string CompanyRequests { get; set; }
        [Display(Name = "Ziyaret Sayısı")]
        public int VisitCount { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatedBy { get; set; }
        [Display(Name = "Güncelleme Tarihi")]
        public DateTime UpdateDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }
    }
}
