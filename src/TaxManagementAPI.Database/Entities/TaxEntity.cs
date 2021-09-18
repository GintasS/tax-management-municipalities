using System.ComponentModel.DataAnnotations;
using TaxManagementAPI.Database.Enums;

namespace TaxManagementAPI.Database.Entities
{
    public class TaxEntity
    {
        [Key]
        public int TaxId { get; set; }
        public TaxType Type { get; set; }
        public MunicipalityEntity MunicipalityEntity { get; set; }
        public TaxRateEntity TaxRateEntity { get; set; }
        public TaxDateEntity TaxDateEntity { get; set; }
    }
}
