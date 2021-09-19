using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaxManagementAPI.Database.Entities;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class NewSingleTaxRequest : TaxModel
    {
        [JsonIgnore]
        public MunicipalityEntity Municipality { get; set; }
    }
}
