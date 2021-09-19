using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxManagementAPI.Core.Interfaces;
using TaxManagementAPI.Core.Models;
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

        public MunicipalityModel CreateNewMunicipalityIfNotExists(string municipalityName)
        {
            var municipality = _context.MunicipalityEntities.SingleOrDefault(x => x.Name == municipalityName);

            if (municipality == null)
            {
                municipality = _context.MunicipalityEntities.Add(new MunicipalityEntity
                {
                    Name = municipalityName
                }).Entity;
            }

            return new MunicipalityModel
            {
                MunicipalityId = municipality.MunicipalityId,
                MunicipalityName = municipality.Name
            };
        }

        public bool MunicipalityExists(string municipalityName)
        {
            return _context.MunicipalityEntities.SingleOrDefault(x => x.Name == municipalityName) != null;
        }
    }
}
