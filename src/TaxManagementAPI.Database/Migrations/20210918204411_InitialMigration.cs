using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TaxManagementAPI.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MunicipalityEntities",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalityEntities", x => x.MunicipalityId);
                });

            migrationBuilder.CreateTable(
                name: "TaxDateEntities",
                columns: table => new
                {
                    TaxDateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxDateEntities", x => x.TaxDateId);
                });

            migrationBuilder.CreateTable(
                name: "TaxRateEntities",
                columns: table => new
                {
                    TaxRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Rate = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRateEntities", x => x.TaxRateId);
                });

            migrationBuilder.CreateTable(
                name: "TaxEntities",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MunicipalityEntityMunicipalityId = table.Column<int>(type: "int", nullable: true),
                    TaxRateEntityTaxRateId = table.Column<int>(type: "int", nullable: true),
                    TaxDateEntityTaxDateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxEntities", x => x.TaxId);
                    table.ForeignKey(
                        name: "FK_TaxEntities_MunicipalityEntities_MunicipalityEntityMunicipal~",
                        column: x => x.MunicipalityEntityMunicipalityId,
                        principalTable: "MunicipalityEntities",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxEntities_TaxDateEntities_TaxDateEntityTaxDateId",
                        column: x => x.TaxDateEntityTaxDateId,
                        principalTable: "TaxDateEntities",
                        principalColumn: "TaxDateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxEntities_TaxRateEntities_TaxRateEntityTaxRateId",
                        column: x => x.TaxRateEntityTaxRateId,
                        principalTable: "TaxRateEntities",
                        principalColumn: "TaxRateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxEntities_MunicipalityEntityMunicipalityId",
                table: "TaxEntities",
                column: "MunicipalityEntityMunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxEntities_TaxDateEntityTaxDateId",
                table: "TaxEntities",
                column: "TaxDateEntityTaxDateId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxEntities_TaxRateEntityTaxRateId",
                table: "TaxEntities",
                column: "TaxRateEntityTaxRateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxEntities");

            migrationBuilder.DropTable(
                name: "MunicipalityEntities");

            migrationBuilder.DropTable(
                name: "TaxDateEntities");

            migrationBuilder.DropTable(
                name: "TaxRateEntities");
        }
    }
}
