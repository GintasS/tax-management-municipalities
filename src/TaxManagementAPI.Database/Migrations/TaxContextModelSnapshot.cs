﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxManagementAPI.Database;

namespace TaxManagementAPI.Database.Migrations
{
    [DbContext(typeof(TaxContext))]
    partial class TaxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("TaxManagementAPI.Database.Entities.MunicipalityEntity", b =>
                {
                    b.Property<int>("MunicipalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MunicipalityId");

                    b.ToTable("MunicipalityEntities");
                });

            modelBuilder.Entity("TaxManagementAPI.Database.Entities.TaxDateEntity", b =>
                {
                    b.Property<int>("TaxDateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime");

                    b.HasKey("TaxDateId");

                    b.ToTable("TaxDateEntities");
                });

            modelBuilder.Entity("TaxManagementAPI.Database.Entities.TaxEntity", b =>
                {
                    b.Property<int>("TaxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MunicipalityEntityMunicipalityId")
                        .HasColumnType("int");

                    b.Property<int?>("TaxDateEntityTaxDateId")
                        .HasColumnType("int");

                    b.Property<int?>("TaxRateEntityTaxRateId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TaxId");

                    b.HasIndex("MunicipalityEntityMunicipalityId");

                    b.HasIndex("TaxDateEntityTaxDateId");

                    b.HasIndex("TaxRateEntityTaxRateId");

                    b.ToTable("TaxEntities");
                });

            modelBuilder.Entity("TaxManagementAPI.Database.Entities.TaxRateEntity", b =>
                {
                    b.Property<int>("TaxRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.HasKey("TaxRateId");

                    b.ToTable("TaxRateEntities");
                });

            modelBuilder.Entity("TaxManagementAPI.Database.Entities.TaxEntity", b =>
                {
                    b.HasOne("TaxManagementAPI.Database.Entities.MunicipalityEntity", "MunicipalityEntity")
                        .WithMany()
                        .HasForeignKey("MunicipalityEntityMunicipalityId");

                    b.HasOne("TaxManagementAPI.Database.Entities.TaxDateEntity", "TaxDateEntity")
                        .WithMany()
                        .HasForeignKey("TaxDateEntityTaxDateId");

                    b.HasOne("TaxManagementAPI.Database.Entities.TaxRateEntity", "TaxRateEntity")
                        .WithMany()
                        .HasForeignKey("TaxRateEntityTaxRateId");

                    b.Navigation("MunicipalityEntity");

                    b.Navigation("TaxDateEntity");

                    b.Navigation("TaxRateEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
