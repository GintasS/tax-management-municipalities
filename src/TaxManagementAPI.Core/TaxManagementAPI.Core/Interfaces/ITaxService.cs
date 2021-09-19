using System;
using System.Collections.Generic;
using TaxManagementAPI.Core.Models;
using TaxManagementAPI.Core.Models.Requests;
using TaxManagementAPI.Core.Models.Responses;

namespace TaxManagementAPI.Core.Interfaces
{
    public interface ITaxService
    {
        public MunicipalityTaxesResponse GetAllTaxes(string municipalityName, DateTime queryDate);
        public UpdateSingleTaxResponse UpdateSingleTax(UpdateSingleTaxRequest request);
        public TaxModel FindSingleTax(int taxId);
    }
}
