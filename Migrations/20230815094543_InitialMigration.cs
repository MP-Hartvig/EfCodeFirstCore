using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCodeFirstCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EmployeeSequence");

            migrationBuilder.CreateTable(
                name: "computer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_department_location_locationid",
                        column: x => x.locationid,
                        principalTable: "location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "developer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EmployeeSequence]"),
                    firstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    streetName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    streetNumber = table.Column<int>(type: "int", nullable: false),
                    privatePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    departmentid = table.Column<int>(type: "int", nullable: false),
                    primaryProgrammingLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_developer_department_departmentid",
                        column: x => x.departmentid,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EmployeeSequence]"),
                    firstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    streetName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    streetNumber = table.Column<int>(type: "int", nullable: false),
                    privatePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    departmentid = table.Column<int>(type: "int", nullable: false),
                    primaryProgrammingLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_manager_department_departmentid",
                        column: x => x.departmentid,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_computer_employeeId",
                table: "computer",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_department_locationid",
                table: "department",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "IX_developer_departmentid",
                table: "developer",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_manager_departmentid",
                table: "manager",
                column: "departmentid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computer");

            migrationBuilder.DropTable(
                name: "developer");

            migrationBuilder.DropTable(
                name: "manager");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropSequence(
                name: "EmployeeSequence");
        }
    }
}
