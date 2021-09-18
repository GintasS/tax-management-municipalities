using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using TaxManagementAPI.Core.Extensions;
using TaxManagementAPI.Core.Interfaces;
using TaxManagementAPI.Core.Models;
using TaxManagementAPI.Core.Models.Requests;
using TaxManagementAPI.Core.Models.Responses;
using TaxManagementAPI.Database;
using TaxManagementAPI.Database.Entities;

namespace TaxManagementAPI.Core.Services
{
    public class TaxService : ITaxService
    {
        private readonly TaxContext _context;

        public TaxService(TaxContext context)
        {
            _context = context;
        }

        public TaxModel FindSingletTax(string municipalityName)
        {
            var taxEntity = _context.TaxEntities
                .Include(x => x.MunicipalityEntity)
                .Include(x => x.TaxDateEntity)
                .Include(x => x.TaxRateEntity)
                .SingleOrDefault(x => x.MunicipalityEntity.Name == municipalityName);

            if (taxEntity == null)
            {
                return null;
            }

            return new TaxModel
            {
                Type = taxEntity.Type,
                MunicipalityName = taxEntity.MunicipalityEntity.Name,
                FromDate = taxEntity.TaxDateEntity.FromDate,
                ToDate = taxEntity.TaxDateEntity.ToDate,
                Rate = taxEntity.TaxRateEntity.Rate
            };
        }

        public MunicipalityTaxesResponse GetAllTaxesForMunicipality(MunicipalityTaxesRequest request)
        {
            var municipality = _context.MunicipalityEntities
                .Include(x => x.TaxEntities)
                .SingleOrDefault(x => x.Name != request.MunicipalityName);

            if (municipality == null)
            {
                return null;
            }

            var filteredTaxes = municipality.TaxEntities
                .Where(entity => entity.TaxDateEntity.FromDate.IsBetweenDate(entity.TaxDateEntity.FromDate, entity.TaxDateEntity.ToDate))
                .Select(entity => new TaxModel
                {
                    Type = entity.Type,
                    MunicipalityName = entity.MunicipalityEntity.Name,
                    FromDate = entity.TaxDateEntity.FromDate,
                    ToDate = entity.TaxDateEntity.ToDate,
                    Rate = entity.TaxRateEntity.Rate
                }).ToList();

            return new MunicipalityTaxesResponse
            {
                Date = request.Date,
                MunicipalityName = request.MunicipalityName,
                Taxes = filteredTaxes
            };
        }

        public UpdateSingleTaxResponse UpdateSingleTax(UpdateSingleTaxRequest request)
        {
            var taxEntity = _context.TaxEntities.SingleOrDefault(x => x.TaxId == request.TaxId);

            if (taxEntity == null)
            {
                return null;
            }

            taxEntity.Type = request.Tax.Type;
            taxEntity.MunicipalityEntity.Name = request.Tax.MunicipalityName;
            taxEntity.TaxDateEntity.FromDate = request.Tax.FromDate;
            taxEntity.TaxDateEntity.ToDate = request.Tax.ToDate;
            taxEntity.TaxRateEntity.Rate = request.Tax.Rate;

            _context.SaveChanges();

            return new UpdateSingleTaxResponse
            {
                Type = taxEntity.Type,
                MunicipalityName = taxEntity.MunicipalityEntity.Name,
                Rate = taxEntity.TaxRateEntity.Rate,
                FromDate = taxEntity.TaxDateEntity.FromDate,
                ToDate = taxEntity.TaxDateEntity.ToDate
            };
        }
    }
}
