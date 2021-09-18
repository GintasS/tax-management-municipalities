using System.ComponentModel.DataAnnotations;

namespace TaxManagementAPI.Database.Entities
{
    public class TaxRateEntity
    {
        [Key]
        public int TaxRateId { get; set; }
        public double Rate { get; set; }
    }
}
