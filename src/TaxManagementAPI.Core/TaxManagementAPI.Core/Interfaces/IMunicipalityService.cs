using TaxManagementAPI.Core.Models;
using TaxManagementAPI.Database.Entities;

namespace TaxManagementAPI.Core.Interfaces
{
    public interface IMunicipalityService
    {
        public bool MunicipalityExists(string municipalityName);
        public MunicipalityEntity CreateNewMunicipalityIfNotExists(string municipalityName);
    }
}