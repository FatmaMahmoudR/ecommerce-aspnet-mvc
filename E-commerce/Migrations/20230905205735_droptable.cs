using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class droptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CompletedOrders_CompletedOrderId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "CompletedOrders");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CompletedOrderId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CompletedOrderId",
                table: "Cards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompletedOrderId",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompletedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedOrders_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CompletedOrderId",
                table: "Cards",
                column: "CompletedOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedOrders_BuyerId",
                table: "CompletedOrders",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CompletedOrders_CompletedOrderId",
                table: "Cards",
                column: "CompletedOrderId",
                principalTable: "CompletedOrders",
                principalColumn: "Id");
        }
    }
}
