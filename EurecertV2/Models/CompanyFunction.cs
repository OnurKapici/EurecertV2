using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class CompanyFunction
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        [Display(Name = "Kurum İşlevi")]
        public string Name { get; set; }
        [StringLength(200)]
        [Display(Name = "İşlev Kodu")]
        public string Code { get; set; }
    }
}
