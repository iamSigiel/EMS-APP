using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_APP.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPARTMENTS LIST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(name: "Department Name", type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS LIST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES LIST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(name: "Email Address", type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ADMIN = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DapartmentID = table.Column<int>(name: "Dapartment ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES LIST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeptID",
                        column: x => x.DapartmentID,
                        principalTable: "DEPARTMENTS LIST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DEPARTMENTS LIST",
                columns: new[] { "ID", "Department Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "EMPLOYEES LIST",
                columns: new[] { "ID", "Dapartment ID", "DOB", "Email Address", "Name", "Phone Number", "ADMIN" },
                values: new object[] { 1, 1, new DateTime(2001, 3, 19, 21, 36, 26, 174, DateTimeKind.Local).AddTicks(6712), "admin@ems.com", "Admin", "09987654321", true });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES LIST_Dapartment ID",
                table: "EMPLOYEES LIST",
                column: "Dapartment ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEES LIST");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS LIST");
        }
    }
}
