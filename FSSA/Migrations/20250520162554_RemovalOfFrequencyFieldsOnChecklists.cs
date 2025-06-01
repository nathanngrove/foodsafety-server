using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSSA.Migrations
{
    /// <inheritdoc />
    public partial class RemovalOfFrequencyFieldsOnChecklists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrequencyCount",
                table: "Checklists");

            migrationBuilder.DropColumn(
                name: "FrequencyType",
                table: "Checklists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FrequencyCount",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FrequencyType",
                table: "Checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
