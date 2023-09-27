using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnsAddedInMatter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Matters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Matters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Matters");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Matters");
        }
    }
}
