using System;
using System.ComponentModel.DataAnnotations;

namespace TaxManagementAPI.Database.Entities
{
    public class TaxDateEntity
    {
        [Key]
        public int TaxDateId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
