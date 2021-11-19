﻿// <auto-generated />
using System;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PrestaFacilDbContext))]
    partial class PrestaFacilDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinancieraAcme.PrestaFacil.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentoIdentidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

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

            modelBuilder.Entity("FinancieraAcme.PrestaFacil.Domain.Entities.LoanApplicationChild", b =>
                {
                    b.Property<int>("LoanApplicationParentId")
                        .HasColumnType("int");

                    b.Property<int>("Item")
                        .HasColumnType("int");

                    b.Property<string>("Producto")
                        .HasColumnType("varchar(500)");

                    b.HasKey("LoanApplicationParentId", "Item");

                    b.ToTable("LoanApplicationChilds");
                });

            modelBuilder.Entity("FinancieraAcme.PrestaFacil.Domain.Entities.LoanApplicationParent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("LoanApplicationParents");
                });

            modelBuilder.Entity("FinancieraAcme.PrestaFacil.Domain.Entities.LoanApplicationChild", b =>
                {
                    b.HasOne("FinancieraAcme.PrestaFacil.Domain.Entities.LoanApplicationParent", "LoanApplicationParent")
                        .WithMany("LoanApplicationChilds")
                        .HasForeignKey("LoanApplicationParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanApplicationParent");
                });

            modelBuilder.Entity("FinancieraAcme.PrestaFacil.Domain.Entities.LoanApplicationParent", b =>
                {
                    b.HasOne("FinancieraAcme.PrestaFacil.Domain.Entities.Client", "Client")
                        .WithMany("LoanApplicationMains")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("FinancieraAcme.PrestaFacil.Domain.Entities.Client", b =>
                {
                    b.Navigation("LoanApplicationMains");
                });

            modelBuilder.Entity("FinancieraAcme.PrestaFacil.Domain.Entities.LoanApplicationParent", b =>
                {
                    b.Navigation("LoanApplicationChilds");
                });
#pragma warning restore 612, 618
        }
    }
}
