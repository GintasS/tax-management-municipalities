using System.Text.Json.Serialization;
using TaxManagementAPI.Database.Entities;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class NewSingleTaxRequest : TaxModel
    {
        [JsonIgnore]
        public MunicipalityEntity Municipality { get; set; }
    }
}
