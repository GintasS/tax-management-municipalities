using System.Linq;
using TaxManagementAPI.Core.Interfaces;
using TaxManagementAPI.Database;
using TaxManagementAPI.Database.Entities;

namespace TaxManagementAPI.Core.Services
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly TaxContext _context;

        public MunicipalityService(TaxContext context)
        {
            _context = context;
        }

        public MunicipalityEntity CreateMunicipality(string municipalityName)
        {
            var municipality = _context.MunicipalityEntities.Add(new MunicipalityEntity
            {
                Name = municipalityName
            }).Entity;

            var numberOfChanges = _context.SaveChanges();
            if (numberOfChanges != 1)
            {
                return null;
            }

            return municipality;
        }

        public MunicipalityEntity FindMunicipality(string municipalityName)
        {
            return _context.MunicipalityEntities.SingleOrDefault(x => x.Name == municipalityName);
        }

        public MunicipalityEntity UpdateMunicipalityName(MunicipalityEntity oldEntity, string newMunicipalityName)
        {
            oldEntity.Name = newMunicipalityName;

            var numberOfChanges = _context.SaveChanges();
            return numberOfChanges != 1 ? null : oldEntity;
        }
    }
}
