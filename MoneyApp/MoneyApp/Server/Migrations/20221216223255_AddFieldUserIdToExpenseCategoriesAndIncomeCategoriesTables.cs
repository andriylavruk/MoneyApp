using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldUserIdToExpenseCategoriesAndIncomeCategoriesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "IncomeCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExpenseCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "IncomeCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExpenseCategories");
        }
    }
}
