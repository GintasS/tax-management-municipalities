using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxManagementAPI.Core.Models.Requests
{
    public class UpdateMunicipalityNameRequest
    {
        [Required]
        public string NewMunicipalityName { get; set; }
    }
}
