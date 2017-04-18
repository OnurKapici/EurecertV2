using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class Consultancy
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public string ReportCode { get; set; }
        public int? ApplicationMethodId { get; set; }
        [ForeignKey("ApplicationMethodId")]
        public virtual ApplicationMethod ApplicationMethod { get; set; }
        public bool IsPresentationDone { get; set; }
        public DateTime? PresentationDate { get; set; }
        public string PresentationFile { get; set; }
        public int? MarketingMethodId { get; set; }
        [ForeignKey("MarketingMethodId")]
        public virtual MarketingMethod MarketingMethod { get; set; }
        public decimal? ProposedBudget { get; set; }
        public DateTime? ProposalDate { get; set; }
        public string CompanyRequests { get; set; }

    }
}
