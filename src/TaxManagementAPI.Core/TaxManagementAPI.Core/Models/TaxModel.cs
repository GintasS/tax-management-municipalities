using System;
using TaxManagementAPI.Database.Enums;

namespace TaxManagementAPI.Core.Models
{
    public class TaxModel
    {
        public string MunicipalityName { get; set; }
        public TaxType Type { get; set; }
        public double Rate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
