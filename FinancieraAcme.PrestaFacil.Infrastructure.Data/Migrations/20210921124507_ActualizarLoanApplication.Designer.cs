// <auto-generated />
using System;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PrestaFacilDbContext))]
    [Migration("20210921124507_ActualizarLoanApplication")]
    partial class ActualizarLoanApplication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinancieraAcme.PrestaFacil.Domain.Entities.LoanApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MontoSolicitado")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.ToTable("LoanApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
