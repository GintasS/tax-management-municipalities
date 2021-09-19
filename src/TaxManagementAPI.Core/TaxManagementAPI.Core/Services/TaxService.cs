using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        private IIncludableQueryable<TaxEntity, TaxRateEntity> GetAllTaxIncludes()
        {
            return _context.TaxEntities
                .Include(x => x.MunicipalityEntity)
                .Include(x => x.TaxDateEntity)
                .Include(x => x.TaxRateEntity);
        }

        public TaxModel FindSingleTax(int taxId)
        {
            var taxEntity = GetAllTaxIncludes()
                .SingleOrDefault(x => x.TaxId == taxId);

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

        public MunicipalityTaxesResponse GetAllTaxes(string municipalityName, DateTime queryDate)
        {
            var filteredTaxes = GetAllTaxIncludes()
                .ToList()
                .Where(entity => entity.MunicipalityEntity.Name == municipalityName && 
                                 queryDate.IsBetweenDate(entity.TaxDateEntity.FromDate, entity.TaxDateEntity.ToDate))
                .Select(entity => new TaxModel
                {
                    Type = entity.Type,
                    MunicipalityName = entity.MunicipalityEntity.Name,
                    FromDate = entity.TaxDateEntity.FromDate,
                    ToDate = entity.TaxDateEntity.ToDate,
                    Rate = entity.TaxRateEntity.Rate
                });

            return new MunicipalityTaxesResponse
            {
                Date = queryDate,
                MunicipalityName = municipalityName,
                Taxes = filteredTaxes
            };
        }

        public UpdateSingleTaxResponse UpdateSingleTax(UpdateSingleTaxRequest request)
        {
            var taxEntity = GetAllTaxIncludes()
                .SingleOrDefault(x => x.TaxId == request.TaxId);
            if (taxEntity == null)
            {
                return null;
            }

            var municipalityEntity = _context.MunicipalityEntities.SingleOrDefault(x => x.Name == request.Municipality.MunicipalityName);
            if (municipalityEntity == null)
            {
                return null;
            }

            taxEntity.Type = request.Type;
            taxEntity.MunicipalityEntity = municipalityEntity;
            taxEntity.TaxDateEntity.FromDate = request.FromDate;
            taxEntity.TaxDateEntity.ToDate = request.ToDate;
            taxEntity.TaxRateEntity.Rate = request.Rate;

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
