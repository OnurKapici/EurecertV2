using System;
using System.Collections.Generic;
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
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public string ReportCode { get; set; }
        public string ImprintCode { get; set; }
        public int? InspectorPersonId { get; set; }
        [ForeignKey("InspectorPersonId")]
        public virtual ApplicationUser InspectorPerson { get; set; }
        public DateTime? InspectionDate { get; set; }
        public int? MarketingMethodId { get; set; }
        [ForeignKey("MarketingMethodId")]
        public virtual MarketingMethod MarketingMethod { get; set; }
        public int? ApplicationMethodId { get; set; }
        [ForeignKey("ApplicationMethodId")]
        public virtual ApplicationMethod ApplicationMethod { get; set; }
        public bool IsPresentationDone { get; set; }
        public DateTime? PresentationDate { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public int? FirstContactPersonId { get; set; }
        [ForeignKey("FirstContactPersonId")]
        public virtual ApplicationUser FirstContactPerson { get; set; }
        public DateTime? FirstInspectionDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? DataSendDate { get; set; }
        public DateTime? ReportReturnDate { get; set; }
        public string ReportPreparedBy { get; set; }
        public string InspectionReport { get; set; }
        public DateTime? ReportRecievedDateByCompany { get; set; }
        public string CompanyAnswerToReport { get; set; }
        public DateTime? StartDateForMissings { get; set; }
        public DateTime? FinishDateForMissings { get; set; }
        public DateTime? LastInspectionDate { get; set; }
        public int? CertificationResultId { get; set; }
        [ForeignKey("CertificationResultId")]
        public virtual CertificationResult CertificationResult { get; set; }
        public DateTime? QualityCertificateDate { get; set; }
        public DateTime? QualityCertificateEndDate { get; set; }
        public DateTime? CertificationInputsCompleteDate { get; set; }
        public int? CertificationInputsUserId { get; set; }
        [ForeignKey("CertificationInputsUserId")]
        public virtual ApplicationUser CertificationInputsUser { get; set; }
        public string InspectorNotes { get; set; }
        public decimal? ProposedBudget { get; set; }
        public string InspectionFile { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }


    }
}
