namespace TaxManagementAPI.Core.Models.Requests
{
    public class UpdateSingleTaxRequest
    {
        public int TaxId { get; set; }
        public TaxModel Tax { get; set; }
    }
}
