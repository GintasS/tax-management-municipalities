using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagementAPI.Database.Entities
{
    public class TaxRateEntity
    {
        [Key]
        public int TaxRateId { get; set; }
        public double Rate { get; set; }
    }
}
