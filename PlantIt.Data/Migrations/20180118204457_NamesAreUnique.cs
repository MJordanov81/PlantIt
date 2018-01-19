using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PlantIt.Data.Migrations
{
    public partial class NamesAreUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Distribution",
                table: "Species",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Vendors_Name",
                table: "Vendors",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Species_Name_Distribution",
                table: "Species",
                columns: new[] { "Name", "Distribution" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Soils_Name",
                table: "Soils",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Locations_Name",
                table: "Locations",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Genera_Name",
                table: "Genera",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Families_Name",
                table: "Families",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AcquisitionTypes_Name",
                table: "AcquisitionTypes",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Vendors_Name",
                table: "Vendors");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Species_Name_Distribution",
                table: "Species");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Soils_Name",
                table: "Soils");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Locations_Name",
                table: "Locations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Genera_Name",
                table: "Genera");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Families_Name",
                table: "Families");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AcquisitionTypes_Name",
                table: "AcquisitionTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Distribution",
                table: "Species",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
