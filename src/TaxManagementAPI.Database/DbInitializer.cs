using System;
using System.Collections.Generic;
using TaxManagementAPI.Database.Entities;
using TaxManagementAPI.Database.Enums;

namespace TaxManagementAPI.Database
{
    public static class DbInitializer
    {
        public static void Initialize(TaxContext context)
        {
            context.Database.EnsureCreated();

            // Municipality Tax Rates.
            var taxRates = new List<TaxRateEntity>
            {
                new()
                {
                    Rate = 0.1
                },
                new()
                {
                    Rate = 0.4
                },
                new()
                {
                    Rate = 0.2
                },
                new()
                {
                    Rate = 0.2
                },
                new()
                {
                    Rate = 0.15
                },
                new()
                {
                    Rate = 0.75
                },
                new()
                {
                    Rate = 0.3
                },
            };

            // Municipality Date Entities.
            var taxeDates = new List<TaxDateEntity>
            {
                new()
                {
                    TaxDateId = 1,
                    FromDate = new DateTime(2021, 1, 1),
                    ToDate = new DateTime(2021, 12, 31)
                },
                new()
                {
                    TaxDateId = 2,
                    FromDate = new DateTime(2021, 5, 1),
                    ToDate = new DateTime(2021, 5, 31)
                },
                new()
                {
                    TaxDateId = 3,
                    FromDate = new DateTime(2021, 1, 1),
                    ToDate = null
                },
                new()
                {
                    TaxDateId = 4,
                    FromDate = new DateTime(2021, 12, 25),
                    ToDate = null
                },
                new()
                {
                    TaxDateId = 5,
                    FromDate = new DateTime(2021, 3, 1),
                    ToDate = new DateTime(2021, 3, 8)
                },
                new()
                {
                    TaxDateId = 6,
                    FromDate = new DateTime(2021, 9, 18),
                    ToDate = new DateTime(2021, 3, 25)
                },
                new()
                {
                    TaxDateId = 7,
                    FromDate = new DateTime(2021, 9, 18),
                    ToDate = new DateTime(2021, 3, 25)
                }
            };


            // Municipality Entities.
            var municipalities = new List<MunicipalityEntity>
            {
                new()
                {
                    MunicipalityId = 1,
                    Name = "Copenhagen"
                },
                new()
                {
                    MunicipalityId = 2,
                    Name = "Vilnius"
                },
                new()
                {
                    MunicipalityId = 3,
                    Name = "London"
                }
            };


            // Municipality Taxes.
            var taxes = new List<TaxEntity>
            {
                new()
                {
                    TaxId = 1,
                    Type = TaxType.Periodic,
                    MunicipalityEntity = municipalities[0],
                    TaxDateEntity = taxeDates[0],
                    TaxRateEntity = taxRates[0]
                },
                new()
                {
                    TaxId = 2,
                    Type = TaxType.Periodic,
                    MunicipalityEntity = municipalities[0],
                    TaxDateEntity = taxeDates[1],
                    TaxRateEntity = taxRates[1]
                },
                new()
                {
                    TaxId = 3,
                    Type = TaxType.Single,
                    MunicipalityEntity = municipalities[0],
                    TaxDateEntity = taxeDates[2],
                    TaxRateEntity = taxRates[2]
                },
                new()
                {
                    TaxId = 4,
                    Type = TaxType.Single,
                    MunicipalityEntity = municipalities[0],
                    TaxDateEntity = taxeDates[3],
                    TaxRateEntity = taxRates[3]
                },
                new()
                {
                    TaxId = 5,
                    Type = TaxType.Periodic,
                    MunicipalityEntity = municipalities[1],
                    TaxDateEntity = taxeDates[4],
                    TaxRateEntity = taxRates[4]
                },
                new()
                {
                    TaxId = 6,
                    Type = TaxType.Periodic,
                    MunicipalityEntity = municipalities[1],
                    TaxDateEntity = taxeDates[5],
                    TaxRateEntity = taxRates[5]
                },
                new()
                {
                    TaxId = 7,
                    Type = TaxType.Periodic,
                    MunicipalityEntity = municipalities[2],
                    TaxDateEntity = taxeDates[6],
                    TaxRateEntity = taxRates[6]
                }
            };

            foreach (var taxRate in taxRates)
            {
                context.TaxRateEntities.Add(taxRate);
            }
            

            foreach (var taxDate in taxeDates)
            {
                context.TaxDateEntities.Add(taxDate);
            }
            
            foreach (var tax in taxes)
            {
                context.TaxEntities.Add(tax);
            }
            

            foreach (var municipality in municipalities)
            {
                context.MunicipalityEntities.Add(municipality);
            }

            context.SaveChanges();
        }
    }
}
