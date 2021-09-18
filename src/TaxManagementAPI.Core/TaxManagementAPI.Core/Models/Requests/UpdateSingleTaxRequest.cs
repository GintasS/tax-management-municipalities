using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class UpdateSingleTaxRequest
    {
        public int TaxId { get; set; }
        public TaxModel Tax { get; set; }
    }
}
