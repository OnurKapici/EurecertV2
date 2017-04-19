using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EurecertV2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(200)]
        [Display(Name = "Tam Ad")]
        public string FullName { get; set; }
        [StringLength(200)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
    }
}
