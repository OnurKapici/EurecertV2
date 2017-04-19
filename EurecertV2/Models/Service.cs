using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        [Display(Name = "Hizmet")]
        public string Name { get; set; }
        public virtual ICollection<CompanyService> CompanyServices { get; set; }
    }
}
