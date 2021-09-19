using System;
using System.Collections.Generic;

namespace TaxManagementAPI.Core.Models.Responses
{
    public class MunicipalityTaxesResponse
    {
        public string MunicipalityName { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<TaxModel> Taxes { get; set; }
    }
}
