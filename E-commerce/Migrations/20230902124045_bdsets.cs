using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class bdsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Buyers_BuyerId",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProduct_Buyers_BuyerID",
                table: "OrderedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProduct_Card_CardID",
                table: "OrderedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProduct_Products_productID",
                table: "OrderedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingInfo_Buyers_buyerID",
                table: "ShippingInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingInfo",
                table: "ShippingInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedProduct",
                table: "OrderedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "ShippingInfo",
                newName: "Shippings");

            migrationBuilder.RenameTable(
                name: "OrderedProduct",
                newName: "OrderedProducts");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingInfo_buyerID",
                table: "Shippings",
                newName: "IX_Shippings_buyerID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProduct_productID",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_productID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProduct_CardID",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_CardID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProduct_BuyerID",
                table: "OrderedProducts",
                newName: "IX_OrderedProducts_BuyerID");

            migrationBuilder.RenameIndex(
                name: "IX_Card_BuyerId",
                table: "Cards",
                newName: "IX_Cards_BuyerId");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shippings",
                table: "Shippings",
                column: "ShippinginfoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Buyers_BuyerId",
                table: "Cards",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Buyers_BuyerID",
                table: "OrderedProducts",
                column: "BuyerID",
                principalTable: "Buyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Cards_CardID",
                table: "OrderedProducts",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProducts_Products_productID",
                table: "OrderedProducts",
                column: "productID",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippings_Buyers_buyerID",
                table: "Shippings",
                column: "buyerID",
                principalTable: "Buyers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Buyers_BuyerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Buyers_BuyerID",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Cards_CardID",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedProducts_Products_productID",
                table: "OrderedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_Buyers_buyerID",
                table: "Shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shippings",
                table: "Shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedProducts",
                table: "OrderedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Shippings",
                newName: "ShippingInfo");

            migrationBuilder.RenameTable(
                name: "OrderedProducts",
                newName: "OrderedProduct");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameIndex(
                name: "IX_Shippings_buyerID",
                table: "ShippingInfo",
                newName: "IX_ShippingInfo_buyerID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_productID",
                table: "OrderedProduct",
                newName: "IX_OrderedProduct_productID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_CardID",
                table: "OrderedProduct",
                newName: "IX_OrderedProduct_CardID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedProducts_BuyerID",
                table: "OrderedProduct",
                newName: "IX_OrderedProduct_BuyerID");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_BuyerId",
                table: "Card",
                newName: "IX_Card_BuyerId");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingInfo",
                table: "ShippingInfo",
                column: "ShippinginfoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedProduct",
                table: "OrderedProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Buyers_BuyerId",
                table: "Card",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProduct_Buyers_BuyerID",
                table: "OrderedProduct",
                column: "BuyerID",
                principalTable: "Buyers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProduct_Card_CardID",
                table: "OrderedProduct",
                column: "CardID",
                principalTable: "Card",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedProduct_Products_productID",
                table: "OrderedProduct",
                column: "productID",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingInfo_Buyers_buyerID",
                table: "ShippingInfo",
                column: "buyerID",
                principalTable: "Buyers",
                principalColumn: "Id");
        }
    }
}
