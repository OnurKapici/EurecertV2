using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EurecertV2.Data.Migrations
{
    public partial class Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultancyServiceFields_Consultancies_ConsultancyId",
                table: "ConsultancyServiceFields");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultancyServiceFields_Consultancies_ConsultancyId",
                table: "ConsultancyServiceFields",
                column: "ConsultancyId",
                principalTable: "Consultancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultancyServiceFields_Consultancies_ConsultancyId",
                table: "ConsultancyServiceFields");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultancyServiceFields_Consultancies_ConsultancyId",
                table: "ConsultancyServiceFields",
                column: "ConsultancyId",
                principalTable: "Consultancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
