using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeedingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budjects_BudgectId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Budjects");

            migrationBuilder.RenameColumn(
                name: "BudgectId",
                table: "Expenses",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_BudgectId",
                table: "Expenses",
                newName: "IX_Expenses_BudgetId");

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                table: "Expenses",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "Expenses",
                newName: "BudgectId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_BudgetId",
                table: "Expenses",
                newName: "IX_Expenses_BudgectId");

            migrationBuilder.CreateTable(
                name: "Budjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budjects", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budjects_BudgectId",
                table: "Expenses",
                column: "BudgectId",
                principalTable: "Budjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
