using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class MarketingMethod
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Tanıtım yönetim alanı boş bırakılamaz.")]
        [Display(Name = "Tanıtım Yöntemi")]
        public string Name { get; set; }
    }
}
