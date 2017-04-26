using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class CertificationResult
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Belgelendirme Sonucu girilmesi zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Belgelendirme Sonucu")]
        public string Name { get; set; }
    }
}
