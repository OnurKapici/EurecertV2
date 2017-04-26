using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class EducationCategory
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Eğitim tipi alanı boş bırakılamaz.")]
        [Display(Name = "Eğitim Tipi")]
        public string Name { get; set; }
    }
}
