using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Invoicedbedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_InvoiceID",
                table: "Items",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Invoices_InvoiceID",
                table: "Items",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Invoices_InvoiceID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_InvoiceID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Items");
        }
    }
}
