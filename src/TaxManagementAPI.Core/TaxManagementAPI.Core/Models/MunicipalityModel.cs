using System.ComponentModel.DataAnnotations;

namespace TaxManagementAPI.Core.Models
{
    public class MunicipalityModel
    {
        [Required]
        public string MunicipalityName { get; set; }
    }
}
