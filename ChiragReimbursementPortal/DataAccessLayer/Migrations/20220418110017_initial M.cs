using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class initialM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReimburesementDetailDb",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReimburementType = table.Column<string>(type: "varchar(25)", nullable: false),
                    RequestedValue = table.Column<string>(type: "varchar(10)", nullable: false),
                    ApprovedValue = table.Column<string>(type: "varchar(10)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(10)", nullable: false),
                    RequestedPhase = table.Column<string>(type: "varchar(25)", nullable: true),
                    Receipt = table.Column<string>(type: "varchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimburesementDetailDb", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReimburesementDetailDb");
        }
    }
}
