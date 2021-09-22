using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Migrations
{
    public partial class AddLoanApplicationMainDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    DocumentoIdentidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationMains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSolicitud = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationMains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationMains_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationMainDetails",
                columns: table => new
                {
                    LoanApplicationMainId = table.Column<int>(nullable: false),
                    Item = table.Column<int>(nullable: false),
                    Producto = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationMainDetails", x => new { x.LoanApplicationMainId, x.Item });
                    table.ForeignKey(
                        name: "FK_LoanApplicationMainDetails_LoanApplicationMains_LoanApplicationMainId",
                        column: x => x.LoanApplicationMainId,
                        principalTable: "LoanApplicationMains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationMains_ClientId",
                table: "LoanApplicationMains",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationMainDetails");

            migrationBuilder.DropTable(
                name: "LoanApplicationMains");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
