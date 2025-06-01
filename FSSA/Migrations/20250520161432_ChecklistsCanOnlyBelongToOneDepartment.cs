using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSSA.Migrations
{
    /// <inheritdoc />
    public partial class ChecklistsCanOnlyBelongToOneDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistDepartment");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Checklists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_DepartmentId",
                table: "Checklists",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_Departments_DepartmentId",
                table: "Checklists",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_Departments_DepartmentId",
                table: "Checklists");

            migrationBuilder.DropIndex(
                name: "IX_Checklists_DepartmentId",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Checklists");

            migrationBuilder.CreateTable(
                name: "ChecklistDepartment",
                columns: table => new
                {
                    ChecklistsChecklistId = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistDepartment", x => new { x.ChecklistsChecklistId, x.DepartmentsDepartmentId });
                    table.ForeignKey(
                        name: "FK_ChecklistDepartment_Checklists_ChecklistsChecklistId",
                        column: x => x.ChecklistsChecklistId,
                        principalTable: "Checklists",
                        principalColumn: "ChecklistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChecklistDepartment_Departments_DepartmentsDepartmentId",
                        column: x => x.DepartmentsDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistDepartment_DepartmentsDepartmentId",
                table: "ChecklistDepartment",
                column: "DepartmentsDepartmentId");
        }
    }
}
