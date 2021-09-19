using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Models
{
    public class TaxDateModel
    {
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
