using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EurecertV2.Data.Migrations
{
    public partial class certificationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_AspNetUsers_FirstContactPersonId",
                table: "Certifications");

            migrationBuilder.DropIndex(
                name: "IX_Certifications_FirstContactPersonId",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "FirstContactPersonId",
                table: "Certifications");

            migrationBuilder.RenameColumn(
                name: "ReportCode",
                table: "Certifications",
                newName: "ProtocolFile");

            migrationBuilder.RenameColumn(
                name: "ImprintCode",
                table: "Certifications",
                newName: "PresentationPerson");

            migrationBuilder.AddColumn<string>(
                name: "FirstContactPerson",
                table: "Certifications",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProposedBudgetCurrency",
                table: "Certifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstContactPerson",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "ProposedBudgetCurrency",
                table: "Certifications");

            migrationBuilder.RenameColumn(
                name: "ProtocolFile",
                table: "Certifications",
                newName: "ReportCode");

            migrationBuilder.RenameColumn(
                name: "PresentationPerson",
                table: "Certifications",
                newName: "ImprintCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDate",
                table: "Certifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstContactPersonId",
                table: "Certifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_FirstContactPersonId",
                table: "Certifications",
                column: "FirstContactPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_AspNetUsers_FirstContactPersonId",
                table: "Certifications",
                column: "FirstContactPersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
