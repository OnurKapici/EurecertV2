using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EurecertV2.Models
{
    public class ConsultancyServiceField
    {
        public int ConsultancyId { get; set; }
        public virtual Consultancy Consultancy { get; set; }
        public int ServiceFieldId { get; set; }
        public virtual ServiceField ServiceField { get; set; }
    }
}
