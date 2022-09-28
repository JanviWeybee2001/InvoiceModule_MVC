using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice_Module.Migrations
{
    public partial class assignItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignParty",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    partyId = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignParty", x => x.id);
                    table.ForeignKey(
                        name: "FK_AssignParty_Party_partyId",
                        column: x => x.partyId,
                        principalTable: "Party",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignParty_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_partyId",
                table: "AssignParty",
                column: "partyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_productId",
                table: "AssignParty",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignParty");
        }
    }
}
