using FinancieraAcme.PrestaFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Model
{
    public class PrestaFacilDbContext: DbContext
    {
        public PrestaFacilDbContext(DbContextOptions<PrestaFacilDbContext> options) : base(options)
        {

        }

        public DbSet<LoanApplication> LoanApplications { get; set; }//this is the name that will go on the database
        public DbSet<Client> Clients { get; set; }
        public DbSet<LoanApplicationMain> LoanApplicationMains { get; set; }
        public DbSet<LoanApplicationMainDetail> LoanApplicationMainDetails { get; set; }
        
        //can initialice tables in the DB for instance names, data types,etc
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SolicitudPrestamo>().ToTable("TBL_MA_SOL");
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoanApplication>()
                .Property(sp => sp.MontoSolicitado)
                .HasColumnType("decimal(7,2)");

            //Foreing Key definition
            modelBuilder.Entity<LoanApplicationMainDetail>()
                .HasKey(sd => new { sd.LoanApplicationMainId, sd.Item });

            modelBuilder.Entity<LoanApplicationMain>()
                .HasOne(sc => sc.Client)
                .WithMany(c => c.LoanApplicationMains)
                .HasForeignKey(fk => fk.ClientId);


            modelBuilder.Entity<LoanApplicationMainDetail>()
                .HasOne(sc => sc.LoanApplicationMain)
                .WithMany(c => c.LoanApplicationMainDetails);
        }
        //Add-Migration ActualizarLoanApplication -Context PrestaFacilDbContext
        //Update-Database -Context PrestaFacilDbContext
        //Apply specific migration
        //Update-Database -Context PrestaFacilDBContext -Migration ActualizarLoanApplication
        //Remove-Migration -Context PrestaFacilDBContext
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.l
    }
}
