using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class Education
    {
        public Education()
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
        [Display(Name = "Tanıtım Yapıldı Mı?")]
        public bool IsMarketingDone { get; set; }
        [Display(Name = "Tanıtım Yöntemi")]
        public int? MarketingMethodId { get; set; }
        [ForeignKey("MarketingMethodId")]
        [Display(Name = "Tanıtım Yöntemi")]
        public virtual MarketingMethod MarketingMethod { get; set; }
        [Display(Name = "Tanıtım Tarihi")]
        [DataType("datetime-local")]
        public DateTime? MarketingDate { get; set; }
        [Display(Name = "Başvuru Yöntemi")]
        public int? ApplicationMethodId { get; set; }
        [Display(Name = "Başvuru Yöntemi")]
        [ForeignKey("ApplicationMethodId")]
        public virtual ApplicationMethod ApplicationMethod { get; set; }
        [Display(Name = "Eğitim Tipi")]
        public int? EducationCategoryId { get; set; }
        [ForeignKey("EducationCategoryId")]
        [Display(Name = "Eğitim Tipi")]
        public virtual EducationCategory EducationCategory { get; set; }
        [StringLength(200)]
        [Display(Name = "Eğitmen")]
        public string Teacher { get; set; }
        [Display(Name = "Teklif Edilen Bütçe")]
        public decimal? ProposedBudget { get; set; }
        [Display(Name = "Teklif Tarihi")]
        [DataType("datetime-local")]
        public DateTime? ProposalDate { get; set; }
        [Display(Name = "Kurumun Talepleri")]
        [DataType(DataType.MultilineText)]
        public string CompanyRequests { get; set; }
        [Display(Name = "Eğitim Başlangıç Tarihi")]
        [DataType("datetime-local")]
        public DateTime? EducationStartDate { get; set; }
        [Display(Name = "Eğitim Bitiş Tarihi")]
        [DataType("datetime-local")]
        public DateTime? EducationFinishDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Eğitim Yeri")]
        public string EducationLocation { get; set; }
        [Display(Name = "Eğitmen Notları")]
        [DataType(DataType.MultilineText)]
        public string TeacherNotes { get; set; }
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
