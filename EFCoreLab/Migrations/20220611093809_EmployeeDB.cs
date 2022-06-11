using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreLab.Migrations
{
    public partial class EmployeeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "VARCHAR(50)", unicode: false, maxLength: 50, nullable: false),
                    EmployeeAddress = table.Column<string>(type: "VARCHAR(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
