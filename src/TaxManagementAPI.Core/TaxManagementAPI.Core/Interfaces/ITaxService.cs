using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
