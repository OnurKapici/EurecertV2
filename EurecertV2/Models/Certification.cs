using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class Certification
    {
        public Certification()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
        public int Id { get; set; }
        [Display(Name = "Kurum")]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Display(Name = "Kurum")]
        public virtual Company Company { get; set; }
        [Display(Name = "Yetkili Denetmen Kişi")]
        public string InspectorPersonId { get; set; }
        [ForeignKey("InspectorPersonId")]
        [Display(Name = "Yetkili Denetmen Kişi")]
        public virtual ApplicationUser InspectorPerson { get; set; }
        [Display(Name = "Denetim Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? InspectionDate { get; set; }
        [Display(Name = "Tanıtım Yöntemi")]
        public int? MarketingMethodId { get; set; }
        [ForeignKey("MarketingMethodId")]
        [Display(Name = "Tanıtım Yöntemi")]
        public virtual MarketingMethod MarketingMethod { get; set; }
        [Display(Name = "Başvuru Yöntemi")]
        public int? ApplicationMethodId { get; set; }
        [ForeignKey("ApplicationMethodId")]
        [Display(Name = "Başvuru Yöntemi")]
        public virtual ApplicationMethod ApplicationMethod { get; set; }
        [Display(Name = "İlk İletişim Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? FirstContactDate { get; set; }
        [Display(Name = "İletişime Geçilen Kişi")]
        [StringLength(200)]
        public string FirstContactPerson { get; set; }
        [Display(Name = "Sunum Yapıldı Mı?")]
        public bool IsPresentationDone { get; set; }
        [Display(Name = "Sunum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? PresentationDate { get; set; }
        [Display(Name = "Sunumu Yapan Kişi")]
        [StringLength(200)]
        public string PresentationPerson { get; set; }
        [Display(Name = "Ön Denetim Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? FirstInspectionDate { get; set; }
        [Display(Name = "Verilerin Almanya'ya Gönderildiği Tarih")]
        [DataType(DataType.Date)]
        public DateTime? DataSendDate { get; set; }
        [Display(Name = "Raporun Getirildiği Tarih")]
        [DataType(DataType.Date)]
        public DateTime? ReportReturnDate { get; set; }
        [Display(Name = "Raporun Kuruma Ulaşma Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? ReportRecievedDateByCompany { get; set; }
        [Display(Name = "Kurumun Rapora Cevabı")]
        [DataType(DataType.MultilineText)]
        public string CompanyAnswerToReport { get; set; }
        [StringLength(200)]
        [Display(Name = "Raporu Hazırlayan Kişi")]
        public string ReportPreparedBy { get; set; }
        [StringLength(200)]
        [Display(Name = "Denetim Raporu Dosyası")]
        public string InspectionReport { get; set; }
        [Display(Name = "Eksikliklere Başlama Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? StartDateForMissings { get; set; }
        [Display(Name = "Eksiklikleri Bitirme Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? FinishDateForMissings { get; set; }
        [Display(Name = "Son Denetim Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? LastInspectionDate { get; set; }
        [Display(Name = "Belgelendirme Sonucu")]
        public int? CertificationResultId { get; set; }
        [Display(Name = "Belgelendirme Sonucu")]
        [ForeignKey("CertificationResultId")]
        public virtual CertificationResult CertificationResult { get; set; }
        [Display(Name = "Kalite Belgesi Verilme/Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? QualityCertificateDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Kalite Belgesi Bitiş Tarihi")]
        public DateTime? QualityCertificateEndDate { get; set; }
        [Display(Name = "Belgelendirme Girdilerinin Tamamlandığı Tarih")]
        [DataType(DataType.Date)]
        public DateTime? CertificationInputsCompleteDate { get; set; }
        [Display(Name = "Belgelendirme Girdilerini Giren Kişi")]
        public string CertificationInputsUserId { get; set; }
        [Display(Name = "Belgelendirime Girdilerini Giren Kişi")]
        [ForeignKey("CertificationInputsUserId")]
        public virtual ApplicationUser CertificationInputsUser { get; set; }
        [Display(Name = "Denetmen Notları")]
        [DataType(DataType.MultilineText)]
        public string InspectorNotes { get; set; }
        [Display(Name = "Teklif Edilen Bütçe")]
        public decimal? ProposedBudget { get; set; }
        [Display(Name = "Teklif Edilen Bütçe Para Birimi")]
        public Currency? ProposedBudgetCurrency { get; set; }
        [Display(Name = "Denetim Dosyası")]
        public string InspectionFile { get; set; }
        [StringLength(200)]
        [Display(Name = "Protokol")]
        public string ProtocolFile { get; set; }
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
