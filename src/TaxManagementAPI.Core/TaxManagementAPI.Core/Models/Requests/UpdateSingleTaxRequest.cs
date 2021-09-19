using System.Text.Json.Serialization;
using TaxManagementAPI.Database.Entities;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class UpdateSingleTaxRequest : TaxModel
    {
        [JsonIgnore]
        public int TaxId { get; set; }
        [JsonIgnore]
        public MunicipalityEntity Municipality { get; set; }
    }
}
