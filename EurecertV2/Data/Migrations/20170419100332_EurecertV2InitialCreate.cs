using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EurecertV2.Data.Migrations
{
    public partial class EurecertV2InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    CompanyFunctionId = table.Column<int>(nullable: true),
                    CompanyRequests = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    DownPayment = table.Column<decimal>(nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Phone = table.Column<string>(maxLength: 200, nullable: true),
                    ProposalAbstract = table.Column<string>(nullable: true),
                    ProposalFile = table.Column<string>(maxLength: 200, nullable: true),
                    ProposalResult = table.Column<string>(nullable: true),
                    SalesPersonId = table.Column<string>(nullable: true),
                    SourceId = table.Column<int>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    VisitCount = table.Column<int>(nullable: false),
                    Website = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_CompanyFunctions_CompanyFunctionId",
                        column: x => x.CompanyFunctionId,
                        principalTable: "CompanyFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationMethodId = table.Column<int>(nullable: true),
                    ApproveDate = table.Column<DateTime>(nullable: true),
                    CertificationInputsCompleteDate = table.Column<DateTime>(nullable: true),
                    CertificationInputsUserId = table.Column<string>(nullable: true),
                    CertificationResultId = table.Column<int>(nullable: true),
                    CompanyAnswerToReport = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    DataSendDate = table.Column<DateTime>(nullable: true),
                    FinishDateForMissings = table.Column<DateTime>(nullable: true),
                    FirstContactDate = table.Column<DateTime>(nullable: true),
                    FirstContactPersonId = table.Column<string>(nullable: true),
                    FirstInspectionDate = table.Column<DateTime>(nullable: true),
                    ImprintCode = table.Column<string>(maxLength: 200, nullable: true),
                    InspectionDate = table.Column<DateTime>(nullable: true),
                    InspectionFile = table.Column<string>(nullable: true),
                    InspectionReport = table.Column<string>(maxLength: 200, nullable: true),
                    InspectorNotes = table.Column<string>(nullable: true),
                    InspectorPersonId = table.Column<string>(nullable: true),
                    IsPresentationDone = table.Column<bool>(nullable: false),
                    LastInspectionDate = table.Column<DateTime>(nullable: true),
                    MarketingMethodId = table.Column<int>(nullable: true),
                    PresentationDate = table.Column<DateTime>(nullable: true),
                    ProposedBudget = table.Column<decimal>(nullable: true),
                    QualityCertificateDate = table.Column<DateTime>(nullable: true),
                    QualityCertificateEndDate = table.Column<DateTime>(nullable: true),
                    ReportCode = table.Column<string>(maxLength: 200, nullable: true),
                    ReportPreparedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ReportRecievedDateByCompany = table.Column<DateTime>(nullable: true),
                    ReportReturnDate = table.Column<DateTime>(nullable: true),
                    StartDateForMissings = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_ApplicationMethods_ApplicationMethodId",
                        column: x => x.ApplicationMethodId,
                        principalTable: "ApplicationMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certifications_AspNetUsers_CertificationInputsUserId",
                        column: x => x.CertificationInputsUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certifications_CertificationResults_CertificationResultId",
                        column: x => x.CertificationResultId,
                        principalTable: "CertificationResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certifications_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certifications_AspNetUsers_FirstContactPersonId",
                        column: x => x.FirstContactPersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certifications_AspNetUsers_InspectorPersonId",
                        column: x => x.InspectorPersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certifications_MarketingMethods_MarketingMethodId",
                        column: x => x.MarketingMethodId,
                        principalTable: "MarketingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyServices",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyServices", x => new { x.CompanyId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_CompanyServices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultancies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationMethodId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    CompanyRequests = table.Column<string>(nullable: true),
                    ConsultancyFinishDate = table.Column<DateTime>(nullable: true),
                    ConsultancyStartDate = table.Column<DateTime>(nullable: true),
                    ConsultantNotes = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsPresentationDone = table.Column<bool>(nullable: false),
                    MarketingMethodId = table.Column<int>(nullable: true),
                    PresentationDate = table.Column<DateTime>(nullable: true),
                    PresentationFile = table.Column<string>(maxLength: 200, nullable: true),
                    ProposalDate = table.Column<DateTime>(nullable: true),
                    ProposedBudget = table.Column<decimal>(nullable: true),
                    ReportCode = table.Column<string>(maxLength: 200, nullable: true),
                    ReportCreateDate = table.Column<DateTime>(nullable: true),
                    ReportCreatedById = table.Column<string>(nullable: true),
                    ReportSendDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultancies_ApplicationMethods_ApplicationMethodId",
                        column: x => x.ApplicationMethodId,
                        principalTable: "ApplicationMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultancies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultancies_MarketingMethods_MarketingMethodId",
                        column: x => x.MarketingMethodId,
                        principalTable: "MarketingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultancies_AspNetUsers_ReportCreatedById",
                        column: x => x.ReportCreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationMethodId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    CompanyRequests = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    EducationCategoryId = table.Column<int>(nullable: true),
                    EducationFinishDate = table.Column<DateTime>(nullable: true),
                    EducationLocation = table.Column<string>(maxLength: 200, nullable: true),
                    EducationStartDate = table.Column<DateTime>(nullable: true),
                    IsMarketingDone = table.Column<bool>(nullable: false),
                    MarketingDate = table.Column<DateTime>(nullable: true),
                    MarketingMethodId = table.Column<int>(nullable: true),
                    ProposalDate = table.Column<DateTime>(nullable: true),
                    ProposedBudget = table.Column<decimal>(nullable: true),
                    ReportCode = table.Column<string>(maxLength: 200, nullable: true),
                    Teacher = table.Column<string>(maxLength: 200, nullable: true),
                    TeacherNotes = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_ApplicationMethods_ApplicationMethodId",
                        column: x => x.ApplicationMethodId,
                        principalTable: "ApplicationMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Educations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Educations_EducationCategories_EducationCategoryId",
                        column: x => x.EducationCategoryId,
                        principalTable: "EducationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Educations_MarketingMethods_MarketingMethodId",
                        column: x => x.MarketingMethodId,
                        principalTable: "MarketingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsultancyServiceFields",
                columns: table => new
                {
                    ConsultancyId = table.Column<int>(nullable: false),
                    ServiceFieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultancyServiceFields", x => new { x.ConsultancyId, x.ServiceFieldId });
                    table.ForeignKey(
                        name: "FK_ConsultancyServiceFields_Consultancies_ConsultancyId",
                        column: x => x.ConsultancyId,
                        principalTable: "Consultancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultancyServiceFields_ServiceFields_ServiceFieldId",
                        column: x => x.ServiceFieldId,
                        principalTable: "ServiceFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_ApplicationMethodId",
                table: "Certifications",
                column: "ApplicationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_CertificationInputsUserId",
                table: "Certifications",
                column: "CertificationInputsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_CertificationResultId",
                table: "Certifications",
                column: "CertificationResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_CompanyId",
                table: "Certifications",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_FirstContactPersonId",
                table: "Certifications",
                column: "FirstContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_InspectorPersonId",
                table: "Certifications",
                column: "InspectorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_MarketingMethodId",
                table: "Certifications",
                column: "MarketingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyFunctionId",
                table: "Companies",
                column: "CompanyFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SalesPersonId",
                table: "Companies",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SourceId",
                table: "Companies",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_ServiceId",
                table: "CompanyServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultancies_ApplicationMethodId",
                table: "Consultancies",
                column: "ApplicationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultancies_CompanyId",
                table: "Consultancies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultancies_MarketingMethodId",
                table: "Consultancies",
                column: "MarketingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultancies_ReportCreatedById",
                table: "Consultancies",
                column: "ReportCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultancyServiceFields_ServiceFieldId",
                table: "ConsultancyServiceFields",
                column: "ServiceFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ApplicationMethodId",
                table: "Educations",
                column: "ApplicationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CompanyId",
                table: "Educations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationCategoryId",
                table: "Educations",
                column: "EducationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_MarketingMethodId",
                table: "Educations",
                column: "MarketingMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "CompanyServices");

            migrationBuilder.DropTable(
                name: "ConsultancyServiceFields");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "CertificationResults");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Consultancies");

            migrationBuilder.DropTable(
                name: "ServiceFields");

            migrationBuilder.DropTable(
                name: "EducationCategories");

            migrationBuilder.DropTable(
                name: "ApplicationMethods");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "MarketingMethods");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CompanyFunctions");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
