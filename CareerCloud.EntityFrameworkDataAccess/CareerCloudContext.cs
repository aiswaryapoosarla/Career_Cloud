using Microsoft.EntityFrameworkCore;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {

        private readonly string _connectionString;

        public CareerCloudContext() => _connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //-----------Set Keys----------------
            modelBuilder.Entity<ApplicantEducationPoco>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantResumePoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantSkillPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyDescriptionPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyJobDescriptionPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyJobEducationPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyJobPoco>()
               .HasKey(p => p.Id);


            modelBuilder.Entity<CompanyJobSkillPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyLocationPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<CompanyProfilePoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<SecurityLoginPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<SecurityLoginsLogPoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<SecurityRolePoco>()
               .HasKey(p => p.Id);


            modelBuilder.Entity<SystemCountryCodePoco>()
               .HasKey(p => p.Code);

            modelBuilder.Entity<SystemLanguageCodePoco>()
               .HasKey(p => p.LanguageID);



            //---------Set Column Properties-------------

            modelBuilder.Entity<ApplicantEducationPoco>()
                .Property(p => p.Id)
                .IsRequired();

            modelBuilder.Entity<ApplicantSkillPoco>()
                .Property(p => p.Applicant)
                .IsRequired();

            modelBuilder.Entity<ApplicantEducationPoco>()
                .Property(p => p.Major)
                .IsRequired();

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .Property(p => p.Id)
                .IsRequired();

            modelBuilder.Entity<ApplicantProfilePoco>()
                .Property(p => p.Id)
                .IsRequired();


            //modelBuilder.Entity<SystemCountryCodePoco>().Ignore(t => t.ApplicantProfiles);
            //modelBuilder.Entity<SystemCountryCodePoco>().Ignore(t => t.ApplicantWorkHistory);
            




            //--------------Relationships---------------------



            //-------ApplicantEducationPoco---------
            modelBuilder.Entity<ApplicantEducationPoco>()
                .HasOne(p => p.ApplicantProfile)
                .WithMany(c => c.ApplicantEducations)
                .HasForeignKey(e => e.Applicant).IsRequired();


            //-------ApplicantJobApplicationPoco---------
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasOne(p => p.ApplicantProfile)
                .WithMany(c => c.ApplicantJobApplications)
                .HasForeignKey(e => e.Applicant).IsRequired();

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasOne(p => p.CompanyJob)
                .WithMany(c => c.ApplicantJobApplications)
                .HasForeignKey(e => e.Job).IsRequired();


            //-------ApplicantProfilePoco---------
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasOne(p => p.SecurityLogin)
                .WithMany(c => c.ApplicantProfiles)
                .HasForeignKey(e => e.Login).IsRequired();

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasOne(p => p.SystemCountryCode)
               .WithMany(c => c.ApplicantProfiles)
               .HasForeignKey(e => e.Country).IsRequired();

            //-------ApplicantResumePoco---------
            modelBuilder.Entity<ApplicantResumePoco>()
                .HasOne(p => p.ApplicantProfile)
                .WithMany(c => c.ApplicantResumes)
                .HasForeignKey(e => e.Applicant).IsRequired();

            //-------ApplicantSkillPoco---------
            modelBuilder.Entity<ApplicantSkillPoco>()
                .HasOne(p => p.ApplicantProfile)
                .WithMany(c => c.ApplicantSkills)
                .HasForeignKey(e => e.Applicant).IsRequired();

            //-------ApplicantWorkHistoryPoco---------
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                .HasOne(p => p.ApplicantProfile)
                .WithMany(c => c.ApplicantWorkHistorys)
                .HasForeignKey(e => e.Applicant).IsRequired();

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                .HasOne(p => p.SystemCountryCode)
                .WithMany(c => c.ApplicantWorkHistorys)
                .HasForeignKey(e => e.CountryCode).IsRequired();

            //-------CompanyDescriptionPoco---------
            modelBuilder.Entity<CompanyDescriptionPoco>()
                .HasOne(p => p.CompanyProfile)
                .WithMany(c => c.CompanyDescriptions)
                .HasForeignKey(e => e.Company).IsRequired();

            modelBuilder.Entity<CompanyDescriptionPoco>()
               .HasOne(p => p.SystemLanguageCode)
               .WithMany(c => c.CompanyDescriptions)
               .HasForeignKey(e => e.LanguageId).IsRequired();

            //-------CompanyJobDescriptionPoco---------
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                .HasOne(p => p.CompanyJob)
                .WithMany(c => c.CompanyJobDescriptions)
                .HasForeignKey(e => e.Job).IsRequired();


            //-------CompanyJobEducationPoco---------
            modelBuilder.Entity<CompanyJobEducationPoco>()
                .HasOne(p => p.CompanyJob)
                .WithMany(c => c.CompanyJobEducations)
                .HasForeignKey(e => e.Job).IsRequired();

            // -------CompanyJobPoco---------
            modelBuilder.Entity<CompanyJobPoco>()
                .HasOne(p => p.CompanyProfile)
                .WithMany(c => c.CompanyJobs)
                .HasForeignKey(e => e.Company).IsRequired();


            // -------CompanyJobSkillPoco---------
            modelBuilder.Entity<CompanyJobSkillPoco>()
                .HasOne(p => p.CompanyJob)
                .WithMany(c => c.CompanyJobSkills)
                .HasForeignKey(e => e.Job).IsRequired();

            // -------CompanyLocationPoco---------
            modelBuilder.Entity<CompanyLocationPoco>()
                .HasOne(p => p.CompanyProfile)
                .WithMany(c => c.CompanyLocations)
                .HasForeignKey(e => e.Company).IsRequired();

            modelBuilder.Entity<CompanyLocationPoco>()
                .HasOne(p => p.SystemCountryCode)
                .WithMany(c => c.CompanyLocations)
                .HasForeignKey(e => e.CountryCode).IsRequired();

            // -------SecurityLoginsLogPoco---------
            modelBuilder.Entity<SecurityLoginsLogPoco>()
                .HasOne(p => p.SecurityLogin)
                .WithMany(c => c.SecurityLoginsLogs)
                .HasForeignKey(e => e.Login).IsRequired();

            // -------SecurityLoginsRolePoco---------
            modelBuilder.Entity<SecurityLoginsRolePoco>()
                .HasOne(p => p.SecurityLogin)
                .WithMany(c => c.SecurityLoginsRoles)
                .HasForeignKey(e => e.Login).IsRequired();

            modelBuilder.Entity<SecurityLoginsRolePoco>()
                .HasOne(p => p.SecurityRole)
                .WithMany(c => c.SecurityLoginsRoles)
                .HasForeignKey(e => e.Role).IsRequired();


        }

        

    }
}
