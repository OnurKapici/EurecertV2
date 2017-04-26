using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class Source
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Haberdar olma şekli boş bırakılamaz.")]
        [Display(Name = "Haberdar Olma Şekli")]
        public string Name { get; set; }
    }
}
