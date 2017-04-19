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
        [StringLength(200)]
        [Display(Name = "Rapor Kodu")]
        public string ReportCode { get; set; }
        [StringLength(200)]
        [Display(Name = "Künye Kodu")]
        public string ImprintCode { get; set; }
        [Display(Name = "Yetkili Denetmen Kişi")]
        public string InspectorPersonId { get; set; }
        [ForeignKey("InspectorPersonId")]
        [Display(Name = "Yetkili Denetmen Kişi")]
        public virtual ApplicationUser InspectorPerson { get; set; }
        [Display(Name = "Denetim Tarihi")]
        [DataType("datetime-local")]
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
        [Display(Name = "Tanıtım Yapıldı Mı?")]
        public bool IsPresentationDone { get; set; }
        [Display(Name = "Tanıtım Tarihi")]
        [DataType("datetime-local")]
        public DateTime? PresentationDate { get; set; }
        [Display(Name = "İlk İletişim Tarihi")]
        [DataType("datetime-local")]
        public DateTime? FirstContactDate { get; set; }
        [Display(Name = "İletişime Geçilen Kişi")]
        public string FirstContactPersonId { get; set; }
        [ForeignKey("FirstContactPersonId")]
        [Display(Name = "İletişime Geçilen Kişi")]
        public virtual ApplicationUser FirstContactPerson { get; set; }
        [Display(Name = "Ön Denetim Tarihi")]
        [DataType("datetime-local")]
        public DateTime? FirstInspectionDate { get; set; }
        [Display(Name = "Onay Tarihi")]
        [DataType("datetime-local")]
        public DateTime? ApproveDate { get; set; }
        [Display(Name = "Verilerin Almanya'ya Gönderildiği Tarih")]
        [DataType("datetime-local")]
        public DateTime? DataSendDate { get; set; }
        [Display(Name = "Raporun Getirildiği Tarih")]
        [DataType("datetime-local")]
        public DateTime? ReportReturnDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Raporu Hazırlayan")]
        public string ReportPreparedBy { get; set; }
        [StringLength(200)]
        [Display(Name = "Denetim Raporu")]
        public string InspectionReport { get; set; }
        [Display(Name = "Raporun Kuruma Ulaşma Tarihi")]
        [DataType("datetime-local")]
        public DateTime? ReportRecievedDateByCompany { get; set; }
        [Display(Name = "Kurum Rapora Cevabı")]
        [DataType(DataType.MultilineText)]
        public string CompanyAnswerToReport { get; set; }
        [Display(Name = "Eksikliklere Başlama Tarihi")]
        [DataType("datetime-local")]
        public DateTime? StartDateForMissings { get; set; }
        [Display(Name = "Eksiklikleri Bitirme Tarihi")]
        [DataType("datetime-local")]
        public DateTime? FinishDateForMissings { get; set; }
        [Display(Name = "Son Denetim Tarihi")]
        [DataType("datetime-local")]
        public DateTime? LastInspectionDate { get; set; }
        [Display(Name = "Belgelendirme Sonucu")]
        public int? CertificationResultId { get; set; }
        [Display(Name = "Belgelendirme Sonucu")]
        [ForeignKey("CertificationResultId")]
        public virtual CertificationResult CertificationResult { get; set; }
        [Display(Name = "Kalite Belgesi Verilme Tarihi")]
        [DataType("datetime-local")]
        public DateTime? QualityCertificateDate { get; set; }
        [DataType("datetime-local")]
        [Display(Name = "Kalite Belgesi Bitiş Tarihi")]
        public DateTime? QualityCertificateEndDate { get; set; }
        [Display(Name = "Belgelendirme Girdilerinin Tamamlandığı Tarih")]
        [DataType("datetime-local")]
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
        [Display(Name = "Denetim Dosyası")]
        public string InspectionFile { get; set; }
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
