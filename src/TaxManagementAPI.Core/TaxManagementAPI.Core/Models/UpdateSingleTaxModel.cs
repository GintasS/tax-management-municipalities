using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Models
{
    public class UpdateSingleTaxModel : TaxModel
    {
        public new int TaxId { get; set; }
    }
}
