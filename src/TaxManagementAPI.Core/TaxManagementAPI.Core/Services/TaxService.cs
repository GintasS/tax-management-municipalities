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

        public TaxEntity FindSingleTax(int taxId)
        {
            return GetAllTaxIncludes()
                .SingleOrDefault(x => x.TaxId == taxId);
        }

        public IEnumerable<TaxModel> GetAllTaxes(string municipalityName, DateTime queryDate)
        {
            var filteredTaxes = GetAllTaxIncludes()
                .ToList()
                .Where(entity => entity.MunicipalityEntity.Name == municipalityName && 
                                 queryDate.IsBetweenDate(entity.TaxDateEntity.FromDate, entity.TaxDateEntity.ToDate))
                .Select(entity => new TaxModel
                {
                    Type = entity.Type,
                    MunicipalityModel = new MunicipalityModel
                    {
                        MunicipalityName = entity.MunicipalityEntity.Name
                    },
                    TaxDateModel = new TaxDateModel
                    {
                        FromDate = entity.TaxDateEntity.FromDate,
                        ToDate = entity.TaxDateEntity.ToDate
                    },
                    TaxRateModel = new TaxRateModel
                    {
                        Rate = entity.TaxRateEntity.Rate
                    }
                });

            return filteredTaxes;
        }

        public TaxModel UpdateSingleTax(UpdateSingleTaxRequest request)
        {
            var taxEntity = GetAllTaxIncludes()
                .SingleOrDefault(x => x.TaxId == request.TaxId);

            if (taxEntity == null)
            {
                return null;
            }

            taxEntity.Type = request.Type;
            taxEntity.TaxDateEntity.FromDate = request.TaxDateModel.FromDate;
            taxEntity.TaxDateEntity.ToDate = request.TaxDateModel.ToDate;
            taxEntity.TaxRateEntity.Rate = request.TaxRateModel.Rate;

            var numberOfChanges = _context.SaveChanges();
            if (numberOfChanges < 1 || numberOfChanges > 4)
            {
                return null;
            }

            return new TaxModel
            {
                Type = taxEntity.Type,
                MunicipalityModel = new MunicipalityModel
                {
                    MunicipalityName = taxEntity.MunicipalityEntity.Name
                },
                TaxDateModel = new TaxDateModel
                {
                    FromDate = taxEntity.TaxDateEntity.FromDate,
                    ToDate = taxEntity.TaxDateEntity.ToDate
                },
                TaxRateModel = new TaxRateModel
                {
                    Rate = taxEntity.TaxRateEntity.Rate
                }
            };
        }

        public UpdateSingleTaxModel InsertSingleTax(NewSingleTaxRequest request)
        {
            var newTax = _context.TaxEntities.Add(new TaxEntity
            {
                Type = request.Type,
                MunicipalityEntity = request.Municipality,
                TaxDateEntity = new TaxDateEntity
                {
                    FromDate = request.TaxDateModel.FromDate,
                    ToDate = request.TaxDateModel.ToDate
                },
                TaxRateEntity = new TaxRateEntity
                {
                    Rate = request.TaxRateModel.Rate
                }
            }).Entity;

            var numberOfChanges = _context.SaveChanges();
            if (numberOfChanges < 3)
            {
                return null;
            }

            return new UpdateSingleTaxModel
            {
                TaxId = newTax.TaxId,
                Type = newTax.Type,
                MunicipalityModel = new MunicipalityModel
                {
                    MunicipalityName = newTax.MunicipalityEntity.Name
                },
                TaxDateModel = new TaxDateModel
                {
                    FromDate = newTax.TaxDateEntity.FromDate,
                    ToDate = newTax.TaxDateEntity.ToDate
                },
                TaxRateModel = new TaxRateModel
                {
                    Rate = newTax.TaxRateEntity.Rate
                }
            };
        }

        public UpdateSingleTaxMunicipalityModel UpdateSingleTaxMunicipality(TaxEntity taxEntity, MunicipalityEntity municipalityEntity)
        {
            taxEntity.MunicipalityEntity = municipalityEntity;

            var numberOfChanges = _context.SaveChanges();
            if (numberOfChanges < 0 || numberOfChanges > 1)
            {
                return null;
            }
            
            return new UpdateSingleTaxMunicipalityModel
            {
                TaxId = taxEntity.TaxId,
                Municipality = new MunicipalityModel
                {
                    MunicipalityName = taxEntity.MunicipalityEntity.Name
                },
            };

        }
    }
}
