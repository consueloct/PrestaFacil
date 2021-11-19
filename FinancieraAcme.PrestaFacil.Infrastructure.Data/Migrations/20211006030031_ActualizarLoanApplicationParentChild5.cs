using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Migrations
{
    public partial class ActualizarLoanApplicationParentChild5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationParents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationParents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationParents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationChilds",
                columns: table => new
                {
                    LoanApplicationParentId = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationChilds", x => new { x.LoanApplicationParentId, x.Item });
                    table.ForeignKey(
                        name: "FK_LoanApplicationChilds_LoanApplicationParents_LoanApplicationParentId",
                        column: x => x.LoanApplicationParentId,
                        principalTable: "LoanApplicationParents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationParents_ClientId",
                table: "LoanApplicationParents",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationChilds");

            migrationBuilder.DropTable(
                name: "LoanApplicationParents");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
