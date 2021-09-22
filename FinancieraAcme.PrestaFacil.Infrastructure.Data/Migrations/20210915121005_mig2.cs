using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanRequests",
                table: "LoanRequests");

            migrationBuilder.RenameTable(
                name: "LoanRequests",
                newName: "LoanApplications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanApplications",
                table: "LoanApplications",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanApplications",
                table: "LoanApplications");

            migrationBuilder.RenameTable(
                name: "LoanApplications",
                newName: "LoanRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanRequests",
                table: "LoanRequests",
                column: "Id");
        }
    }
}
