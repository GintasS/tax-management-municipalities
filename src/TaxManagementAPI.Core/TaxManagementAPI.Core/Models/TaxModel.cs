using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaxManagementAPI.Database.Enums;

namespace TaxManagementAPI.Core.Models
{
    public class TaxModel
    {
        [JsonIgnore]
        public int TaxId { get; set; }
        public TaxType Type { get; set; }
        [Required]
        public MunicipalityModel MunicipalityModel { get; set; }
        [Required]
        public TaxRateModel TaxRateModel { get; set; }
        [Required]
        public TaxDateModel TaxDateModel { get; set; }
    }
}
