using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice_Module.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductRate_productId",
                table: "ProductRate");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_productId",
                table: "ProductRate",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductRate_productId",
                table: "ProductRate");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_productId",
                table: "ProductRate",
                column: "productId",
                unique: true);
        }
    }
}
