using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class CompanyService
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
