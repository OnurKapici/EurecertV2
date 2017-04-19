using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class ServiceField
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        [Display(Name = "Hizmet Alanı")]
        public string Name { get; set; }
        public virtual ICollection<ConsultancyServiceField> ConsultancyServiceFields { get; set; }
    }
}
