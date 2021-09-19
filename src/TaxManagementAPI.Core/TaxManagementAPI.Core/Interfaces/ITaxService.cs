using System;
using System.Collections.Generic;
using TaxManagementAPI.Core.Models;
using TaxManagementAPI.Core.Models.Requests;
using TaxManagementAPI.Core.Models.Responses;
using TaxManagementAPI.Database.Entities;

namespace TaxManagementAPI.Core.Interfaces
{
    public interface ITaxService
    {
        public IEnumerable<TaxModel> GetAllTaxes(string municipalityName, DateTime queryDate);
        public TaxModel UpdateSingleTax(UpdateSingleTaxRequest request);
        public TaxEntity FindSingleTax(int taxId);
        public UpdateSingleTaxModel InsertSingleTax(NewSingleTaxRequest request);
        public UpdateSingleTaxMunicipalityModel UpdateSingleTaxMunicipality(TaxEntity taxEntity, MunicipalityEntity municipalityEntity);
    }
}
