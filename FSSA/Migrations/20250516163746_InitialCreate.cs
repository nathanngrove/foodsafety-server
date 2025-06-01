using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSSA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checklists",
                columns: table => new
                {
                    ChecklistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChecklistTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChecklistType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequencyCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequencyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.ChecklistId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

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

            migrationBuilder.CreateTable(
                name: "DepartmentStore",
                columns: table => new
                {
                    DepartmentsDepartmentId = table.Column<int>(type: "int", nullable: false),
                    StoresStoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentStore", x => new { x.DepartmentsDepartmentId, x.StoresStoreId });
                    table.ForeignKey(
                        name: "FK_DepartmentStore_Departments_DepartmentsDepartmentId",
                        column: x => x.DepartmentsDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentStore_Stores_StoresStoreId",
                        column: x => x.StoresStoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmittedBy = table.Column<int>(type: "int", nullable: true),
                    CleanUpLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ChecklistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_Entries_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklists",
                        principalColumn: "ChecklistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistDepartment_DepartmentsDepartmentId",
                table: "ChecklistDepartment",
                column: "DepartmentsDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentStore_StoresStoreId",
                table: "DepartmentStore",
                column: "StoresStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ChecklistId",
                table: "Entries",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_StoreId",
                table: "Entries",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistDepartment");

            migrationBuilder.DropTable(
                name: "DepartmentStore");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Checklists");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
