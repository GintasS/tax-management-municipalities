using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Models
{
    public class UpdateSingleTaxMunicipalityModel
    {
        public int TaxId { get; set; }
        public MunicipalityModel Municipality { get; set; }
    }
}
