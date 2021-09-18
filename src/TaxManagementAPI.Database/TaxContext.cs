using System;
using Microsoft.EntityFrameworkCore;
using TaxManagementAPI.Database.Entities;
using TaxManagementAPI.Database.Enums;

namespace TaxManagementAPI.Database
{
    public class TaxContext : DbContext
    {
        public DbSet<MunicipalityEntity> MunicipalityEntities { get; set; }
        public DbSet<TaxEntity> TaxEntities { get; set; }
        public DbSet<TaxRateEntity> TaxRateEntities { get; set; }
        public DbSet<TaxDateEntity> TaxDateEntities { get; set; }

        public TaxContext(DbContextOptions<TaxContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaxEntity>(entity =>
                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasConversion(
                        v => v.ToString(),
                        v => (TaxType)Enum.Parse(typeof(TaxType), v))
                    .IsUnicode(false)
            );
        }

    }
}
