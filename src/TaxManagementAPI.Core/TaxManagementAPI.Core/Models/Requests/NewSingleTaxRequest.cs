using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaxManagementAPI.Database.Entities;
using TaxManagementAPI.Database.Enums;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class NewSingleTaxRequest
    {
        public TaxType Type { get; set; }
        [Required]
        public TaxRateModel TaxRateModel { get; set; }
        [Required]
        public TaxDateModel TaxDateModel { get; set; }
        [JsonIgnore]
        public MunicipalityEntity Municipality { get; set; }
    }
}
