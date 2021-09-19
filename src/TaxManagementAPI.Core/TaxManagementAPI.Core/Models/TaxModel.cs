using TaxManagementAPI.Database.Enums;

namespace TaxManagementAPI.Core.Models
{
    public class TaxModel
    {
        public TaxType Type { get; set; }
        public MunicipalityModel MunicipalityModel { get; set; }
        public TaxRateModel TaxRateModel { get; set; }
        public TaxDateModel TaxDateModel { get; set; }
    }
}
