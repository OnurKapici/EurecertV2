using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public int? CompanyFunctionId { get; set; }
        [ForeignKey("CompanyFunctionId")]
        public virtual CompanyFunction CompanyFunction { get; set; }
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public int? SourceId { get; set; }
        [ForeignKey("SourceId")]
        public virtual Source Source { get; set; }
        public int? SalesPersonId { get; set; }
        [ForeignKey("SalesPersonId")]
        public virtual ApplicationUser SalesPerson { get; set; }
        public string ProposalAbstract { get; set; }
        public string ProposalFile { get; set; }
        public string ProposalResult { get; set; }
        public decimal? DownPayment { get; set; }
        public decimal? TotalAmount { get; set; }
        public virtual ICollection<CompanyService> CompanyServices { get; set; }
        public string CompanyRequests { get; set; }
        public int VisitCount { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
