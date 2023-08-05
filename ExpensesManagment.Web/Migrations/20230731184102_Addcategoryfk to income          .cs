using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesManagment.Web.Migrations
{
    public partial class Addcategoryfktoincome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryFk",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryFk",
                table: "Incomes");
        }
    }
}
