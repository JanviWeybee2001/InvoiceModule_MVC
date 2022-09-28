using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice_Module.Migrations
{
    public partial class changess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_productName",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Party_partyName",
                table: "Party");

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "partyName",
                table: "Party",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "partyName",
                table: "Party",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_productName",
                table: "Product",
                column: "productName",
                unique: true,
                filter: "[productName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Party_partyName",
                table: "Party",
                column: "partyName",
                unique: true,
                filter: "[partyName] IS NOT NULL");
        }
    }
}
