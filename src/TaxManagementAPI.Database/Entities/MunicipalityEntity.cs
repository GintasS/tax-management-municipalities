using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxManagementAPI.Database.Entities
{
    public class MunicipalityEntity
    {
        [Key]
        public int MunicipalityId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<TaxEntity> TaxEntities { get; set; }
    }
}
