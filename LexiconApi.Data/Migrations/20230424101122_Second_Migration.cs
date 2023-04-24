using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Attorneys_AttorneyId",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Attorneys_AttorneyId",
                table: "Invoices",
                column: "AttorneyId",
                principalTable: "Attorneys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Attorneys_AttorneyId",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Attorneys_AttorneyId",
                table: "Invoices",
                column: "AttorneyId",
                principalTable: "Attorneys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
