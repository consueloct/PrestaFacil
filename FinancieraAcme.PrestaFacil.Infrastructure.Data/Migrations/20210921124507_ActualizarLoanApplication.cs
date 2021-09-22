using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Migrations
{
    public partial class ActualizarLoanApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MontoSolicitado",
                table: "LoanApplications",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Cliente",
                table: "LoanApplications",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MontoSolicitado",
                table: "LoanApplications",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Cliente",
                table: "LoanApplications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)");
        }
    }
}
