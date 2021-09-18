using System;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class MunicipalityTaxesRequest
    {
        public string MunicipalityName { get; set; }
        public DateTime Date { get; set; }
    }
}
