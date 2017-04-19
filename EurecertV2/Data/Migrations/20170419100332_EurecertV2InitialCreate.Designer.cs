using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EurecertV2.Data;

namespace EurecertV2.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170419100332_EurecertV2InitialCreate")]
    partial class EurecertV2InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EurecertV2.Models.ApplicationMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("ApplicationMethods");
                });

            modelBuilder.Entity("EurecertV2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .HasMaxLength(200);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone")
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EurecertV2.Models.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationMethodId");

                    b.Property<DateTime?>("ApproveDate");

                    b.Property<DateTime?>("CertificationInputsCompleteDate");

                    b.Property<string>("CertificationInputsUserId");

                    b.Property<int?>("CertificationResultId");

                    b.Property<string>("CompanyAnswerToReport");

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("DataSendDate");

                    b.Property<DateTime?>("FinishDateForMissings");

                    b.Property<DateTime?>("FirstContactDate");

                    b.Property<string>("FirstContactPersonId");

                    b.Property<DateTime?>("FirstInspectionDate");

                    b.Property<string>("ImprintCode")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("InspectionDate");

                    b.Property<string>("InspectionFile");

                    b.Property<string>("InspectionReport")
                        .HasMaxLength(200);

                    b.Property<string>("InspectorNotes");

                    b.Property<string>("InspectorPersonId");

                    b.Property<bool>("IsPresentationDone");

                    b.Property<DateTime?>("LastInspectionDate");

                    b.Property<int?>("MarketingMethodId");

                    b.Property<DateTime?>("PresentationDate");

                    b.Property<decimal?>("ProposedBudget");

                    b.Property<DateTime?>("QualityCertificateDate");

                    b.Property<DateTime?>("QualityCertificateEndDate");

                    b.Property<string>("ReportCode")
                        .HasMaxLength(200);

                    b.Property<string>("ReportPreparedBy")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ReportRecievedDateByCompany");

                    b.Property<DateTime?>("ReportReturnDate");

                    b.Property<DateTime?>("StartDateForMissings");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationMethodId");

                    b.HasIndex("CertificationInputsUserId");

                    b.HasIndex("CertificationResultId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FirstContactPersonId");

                    b.HasIndex("InspectorPersonId");

                    b.HasIndex("MarketingMethodId");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("EurecertV2.Models.CertificationResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("CertificationResults");
                });

            modelBuilder.Entity("EurecertV2.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EurecertV2.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("CityId");

                    b.Property<int?>("CompanyFunctionId");

                    b.Property<string>("CompanyRequests");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<decimal?>("DownPayment");

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Phone")
                        .HasMaxLength(200);

                    b.Property<string>("ProposalAbstract");

                    b.Property<string>("ProposalFile")
                        .HasMaxLength(200);

                    b.Property<string>("ProposalResult");

                    b.Property<string>("SalesPersonId");

                    b.Property<int?>("SourceId");

                    b.Property<decimal?>("TotalAmount");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.Property<int>("VisitCount");

                    b.Property<string>("Website")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyFunctionId");

                    b.HasIndex("CountryId");

                    b.HasIndex("SalesPersonId");

                    b.HasIndex("SourceId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EurecertV2.Models.CompanyFunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("CompanyFunctions");
                });

            modelBuilder.Entity("EurecertV2.Models.CompanyService", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("ServiceId");

                    b.HasKey("CompanyId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CompanyServices");
                });

            modelBuilder.Entity("EurecertV2.Models.Consultancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationMethodId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CompanyRequests");

                    b.Property<DateTime?>("ConsultancyFinishDate");

                    b.Property<DateTime?>("ConsultancyStartDate");

                    b.Property<string>("ConsultantNotes");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<bool>("IsPresentationDone");

                    b.Property<int?>("MarketingMethodId");

                    b.Property<DateTime?>("PresentationDate");

                    b.Property<string>("PresentationFile")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ProposalDate");

                    b.Property<decimal?>("ProposedBudget");

                    b.Property<string>("ReportCode")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ReportCreateDate");

                    b.Property<string>("ReportCreatedById");

                    b.Property<DateTime?>("ReportSendDate");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationMethodId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MarketingMethodId");

                    b.HasIndex("ReportCreatedById");

                    b.ToTable("Consultancies");
                });

            modelBuilder.Entity("EurecertV2.Models.ConsultancyServiceField", b =>
                {
                    b.Property<int>("ConsultancyId");

                    b.Property<int>("ServiceFieldId");

                    b.HasKey("ConsultancyId", "ServiceFieldId");

                    b.HasIndex("ServiceFieldId");

                    b.ToTable("ConsultancyServiceFields");
                });

            modelBuilder.Entity("EurecertV2.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("EurecertV2.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationMethodId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CompanyRequests");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(200);

                    b.Property<int?>("EducationCategoryId");

                    b.Property<DateTime?>("EducationFinishDate");

                    b.Property<string>("EducationLocation")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("EducationStartDate");

                    b.Property<bool>("IsMarketingDone");

                    b.Property<DateTime?>("MarketingDate");

                    b.Property<int?>("MarketingMethodId");

                    b.Property<DateTime?>("ProposalDate");

                    b.Property<decimal?>("ProposedBudget");

                    b.Property<string>("ReportCode")
                        .HasMaxLength(200);

                    b.Property<string>("Teacher")
                        .HasMaxLength(200);

                    b.Property<string>("TeacherNotes");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationMethodId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EducationCategoryId");

                    b.HasIndex("MarketingMethodId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("EurecertV2.Models.EducationCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("EducationCategories");
                });

            modelBuilder.Entity("EurecertV2.Models.MarketingMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("MarketingMethods");
                });

            modelBuilder.Entity("EurecertV2.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("EurecertV2.Models.ServiceField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("ServiceFields");
                });

            modelBuilder.Entity("EurecertV2.Models.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EurecertV2.Models.Certification", b =>
                {
                    b.HasOne("EurecertV2.Models.ApplicationMethod", "ApplicationMethod")
                        .WithMany()
                        .HasForeignKey("ApplicationMethodId");

                    b.HasOne("EurecertV2.Models.ApplicationUser", "CertificationInputsUser")
                        .WithMany()
                        .HasForeignKey("CertificationInputsUserId");

                    b.HasOne("EurecertV2.Models.CertificationResult", "CertificationResult")
                        .WithMany()
                        .HasForeignKey("CertificationResultId");

                    b.HasOne("EurecertV2.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("EurecertV2.Models.ApplicationUser", "FirstContactPerson")
                        .WithMany()
                        .HasForeignKey("FirstContactPersonId");

                    b.HasOne("EurecertV2.Models.ApplicationUser", "InspectorPerson")
                        .WithMany()
                        .HasForeignKey("InspectorPersonId");

                    b.HasOne("EurecertV2.Models.MarketingMethod", "MarketingMethod")
                        .WithMany()
                        .HasForeignKey("MarketingMethodId");
                });

            modelBuilder.Entity("EurecertV2.Models.City", b =>
                {
                    b.HasOne("EurecertV2.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EurecertV2.Models.Company", b =>
                {
                    b.HasOne("EurecertV2.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("EurecertV2.Models.CompanyFunction", "CompanyFunction")
                        .WithMany()
                        .HasForeignKey("CompanyFunctionId");

                    b.HasOne("EurecertV2.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("EurecertV2.Models.ApplicationUser", "SalesPerson")
                        .WithMany()
                        .HasForeignKey("SalesPersonId");

                    b.HasOne("EurecertV2.Models.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");
                });

            modelBuilder.Entity("EurecertV2.Models.CompanyService", b =>
                {
                    b.HasOne("EurecertV2.Models.Company", "Company")
                        .WithMany("CompanyServices")
                        .HasForeignKey("CompanyId");

                    b.HasOne("EurecertV2.Models.Service", "Service")
                        .WithMany("CompanyServices")
                        .HasForeignKey("ServiceId");
                });

            modelBuilder.Entity("EurecertV2.Models.Consultancy", b =>
                {
                    b.HasOne("EurecertV2.Models.ApplicationMethod", "ApplicationMethod")
                        .WithMany()
                        .HasForeignKey("ApplicationMethodId");

                    b.HasOne("EurecertV2.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("EurecertV2.Models.MarketingMethod", "MarketingMethod")
                        .WithMany()
                        .HasForeignKey("MarketingMethodId");

                    b.HasOne("EurecertV2.Models.ApplicationUser", "ReportCreatedBy")
                        .WithMany()
                        .HasForeignKey("ReportCreatedById");
                });

            modelBuilder.Entity("EurecertV2.Models.ConsultancyServiceField", b =>
                {
                    b.HasOne("EurecertV2.Models.Consultancy", "Consultancy")
                        .WithMany("ConsultancyServiceFields")
                        .HasForeignKey("ConsultancyId");

                    b.HasOne("EurecertV2.Models.ServiceField", "ServiceField")
                        .WithMany("ConsultancyServiceFields")
                        .HasForeignKey("ServiceFieldId");
                });

            modelBuilder.Entity("EurecertV2.Models.Education", b =>
                {
                    b.HasOne("EurecertV2.Models.ApplicationMethod", "ApplicationMethod")
                        .WithMany()
                        .HasForeignKey("ApplicationMethodId");

                    b.HasOne("EurecertV2.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("EurecertV2.Models.EducationCategory", "EducationCategory")
                        .WithMany()
                        .HasForeignKey("EducationCategoryId");

                    b.HasOne("EurecertV2.Models.MarketingMethod", "MarketingMethod")
                        .WithMany()
                        .HasForeignKey("MarketingMethodId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EurecertV2.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EurecertV2.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EurecertV2.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
