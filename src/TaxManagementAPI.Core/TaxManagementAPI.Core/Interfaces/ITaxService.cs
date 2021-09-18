using TaxManagementAPI.Core.Models;
using TaxManagementAPI.Core.Models.Requests;
using TaxManagementAPI.Core.Models.Responses;

namespace TaxManagementAPI.Core.Interfaces
{
    interface ITaxService
    {
        public MunicipalityTaxesResponse GetAllTaxesForMunicipality(MunicipalityTaxesRequest request);
        public UpdateSingleTaxResponse UpdateSingleTax(UpdateSingleTaxRequest request);
        public TaxModel FindSingletTax(string municipalityId);
    }
}
