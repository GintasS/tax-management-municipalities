using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Models.Responses
{
    public class UpdateMunicipalityNameResponse
    {
        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; }
    }
}
