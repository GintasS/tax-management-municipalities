using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class MunicipalityTaxesRequest
    {
        public string MunicipalityName { get; set; }
        public DateTime Date { get; set; }
    }
}
