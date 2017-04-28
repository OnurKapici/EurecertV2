using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EurecertV2.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EurecertV2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationMethod> ApplicationMethods { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<CertificationResult> CertificationResults { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyFunction> CompanyFunctions { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }
        public DbSet<Consultancy> Consultancies { get; set; }
        public DbSet<ConsultancyServiceField> ConsultancyServiceFields { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationCategory> EducationCategories { get; set; }
        public DbSet<MarketingMethod> MarketingMethods { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceField> ServiceFields { get; set; }
        public DbSet<Source> Sources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ConsultancyServiceField>()
                .HasKey(f => new { f.ConsultancyId, f.ServiceFieldId });

            builder.Entity<ConsultancyServiceField>()
                .HasOne(f => f.Consultancy)
                .WithMany(mu => mu.ConsultancyServiceFields)
                .HasForeignKey(f => f.ConsultancyId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ConsultancyServiceField>()
                .HasOne(f => f.ServiceField)
                .WithMany(mu => mu.ConsultancyServiceFields)
                .HasForeignKey(f => f.ServiceFieldId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CompanyService>()
                .HasKey(f => new { f.CompanyId, f.ServiceId });

            builder.Entity<CompanyService>()
                .HasOne(f => f.Company)
                .WithMany(mu => mu.CompanyServices)
                .HasForeignKey(f => f.CompanyId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CompanyService>()
                .HasOne(f => f.Service)
                .WithMany(mu => mu.CompanyServices)
                .HasForeignKey(f => f.ServiceId).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<EurecertV2.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
