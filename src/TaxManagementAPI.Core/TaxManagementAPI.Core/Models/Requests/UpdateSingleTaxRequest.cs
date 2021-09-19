using System.Text.Json.Serialization;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class UpdateSingleTaxRequest : TaxModel
    {
        [JsonIgnore]
        public int TaxId { get; set; }
    }
}
