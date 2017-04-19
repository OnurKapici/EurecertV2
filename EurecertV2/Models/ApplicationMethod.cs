using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class ApplicationMethod
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name="Başvuru Yöntemi")]
        public string Name { get; set; }
    }
}
