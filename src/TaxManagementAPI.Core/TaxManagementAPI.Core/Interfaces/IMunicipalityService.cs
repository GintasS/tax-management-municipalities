using TaxManagementAPI.Database.Entities;

namespace TaxManagementAPI.Core.Interfaces
{
    public interface IMunicipalityService
    {
        public MunicipalityEntity FindMunicipality(string municipalityName);
        public MunicipalityEntity CreateMunicipality(string municipalityName);
        public MunicipalityEntity UpdateMunicipalityName(MunicipalityEntity oldEntity, string newMunicipalityName);
    }
}