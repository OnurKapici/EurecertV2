using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class Consultancy
    {
        public Consultancy()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            ConsultancyServiceFields = new HashSet<ConsultancyServiceField>();
        }
        public int Id { get; set; }
        [Display(Name = "Kurum")]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Display(Name = "Kurum")]
        public virtual Company Company { get; set; }
        [StringLength(200)]
        [Display(Name = "Rapor Kodu")]
        public string ReportCode { get; set; }
        [Display(Name = "Başvuru Yöntemi")]
        public int? ApplicationMethodId { get; set; }
        [ForeignKey("ApplicationMethodId")]
        [Display(Name = "Başvuru Yöntemi")]
        public virtual ApplicationMethod ApplicationMethod { get; set; }
        [Display(Name = "Sunum Yapıldı Mı?")]
        public bool IsPresentationDone { get; set; }
        [Display(Name = "Sunum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? PresentationDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Sunum Dosyası")]
        public string PresentationFile { get; set; }
        [Display(Name = "Tanıtım Yöntemi")]
        public int? MarketingMethodId { get; set; }
        [ForeignKey("MarketingMethodId")]
        [Display(Name = "Tanıtım Yöntemi")]
        public virtual MarketingMethod MarketingMethod { get; set; }
        [Display(Name = "Teklif Edilen Bütçe")]
        public decimal? ProposedBudget { get; set; }
        [Display(Name = "Teklif Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? ProposalDate { get; set; }
        [Display(Name = "Kurumun Talepleri")]
        [DataType(DataType.MultilineText)]
        public string CompanyRequests { get; set; }
        [Display(Name = "Danışmanlık Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? ConsultancyStartDate { get; set; }
        [Display(Name = "Danışmanlık Bitiş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? ConsultancyFinishDate { get; set; }
        [Display(Name = "Rapor Oluşturma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? ReportCreateDate { get; set; }
        [Display(Name = "Rapor Oluşturan Kişi")]
        public string ReportCreatedById { get; set; }
        [ForeignKey("ReportCreatedById")]
        [Display(Name = "Rapor Oluşturan Kişi")]
        public virtual ApplicationUser ReportCreatedBy { get; set; }
        [Display(Name = "Raporun Gönderilme Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? ReportSendDate { get; set; }
        [Display(Name = "Danışman Notları")]
        [DataType(DataType.MultilineText)]
        public string ConsultantNotes { get; set; }
        [Display(Name = "Hizmet Alanları")]
        public virtual ICollection<ConsultancyServiceField> ConsultancyServiceFields { get; set; }
        [NotMapped]
        public int[] ServiceFields { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatedBy { get; set; }
        [Display(Name = "Güncellenme Tarihi")]
        public DateTime UpdateDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }
    }
}
