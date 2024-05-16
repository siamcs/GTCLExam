using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTCLExam.Migrations
{
    /// <inheritdoc />
    public partial class Init5uu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "EmployeeInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "EmployeeInfos");
        }
    }
}
