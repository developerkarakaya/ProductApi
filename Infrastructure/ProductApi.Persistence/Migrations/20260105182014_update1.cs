using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 565, DateTimeKind.Local).AddTicks(313), "Movies" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 565, DateTimeKind.Local).AddTicks(4866), "Automotive, Tools & Computers" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 565, DateTimeKind.Local).AddTicks(6436), "Books & Electronics" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 565, DateTimeKind.Local).AddTicks(6667), "Sports, Clothing & Industrial" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 565, DateTimeKind.Local).AddTicks(6796), "Shoes" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 565, DateTimeKind.Local).AddTicks(6882), "Home" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 566, DateTimeKind.Local).AddTicks(2318), "Kids & Grocery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 566, DateTimeKind.Local).AddTicks(2863), "Garden, Home & Games" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 566, DateTimeKind.Local).AddTicks(3068), "Grocery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 566, DateTimeKind.Local).AddTicks(4293), "Baby, Grocery & Jewelery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 5, 21, 20, 13, 568, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 5, 21, 20, 13, 568, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 5, 21, 20, 13, 568, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 5, 21, 20, 13, 568, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 575, DateTimeKind.Local).AddTicks(1835), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Handmade Cotton Keyboard" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 575, DateTimeKind.Local).AddTicks(1985), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Unbranded Plastic Pants" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 575, DateTimeKind.Local).AddTicks(2117), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Fantastic Metal Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 598, DateTimeKind.Local).AddTicks(8355), "The Football Is Good For Training And Recreational Purposes", 2.652548715042895m, 320.24m, "Refined Wooden Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2026, 1, 5, 21, 20, 13, 598, DateTimeKind.Local).AddTicks(9538), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 6.396776557963768m, 238.32m, "Rustic Concrete Shirt" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(421), "Jewelery & Kids" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(5454), "Sports" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(5605), "Games" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(5732), "Outdoors & Movies" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(5985), "Music, Sports & Clothing" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(456), "Outdoors & Jewelery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(1614), "Books & Kids" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(1853), "Electronics" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(1947), "Tools & Books" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(2054), "Computers" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 1, 1, 22, 26, 172, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 1, 1, 22, 26, 172, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 1, 1, 22, 26, 172, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 1, 1, 22, 26, 172, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 175, DateTimeKind.Local).AddTicks(3477), "The Football Is Good For Training And Recreational Purposes", "Ergonomic Granite Ball" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 175, DateTimeKind.Local).AddTicks(3531), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Ergonomic Concrete Bike" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 175, DateTimeKind.Local).AddTicks(3559), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Handmade Rubber Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 182, DateTimeKind.Local).AddTicks(5000), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 4.602938602861063m, 216.06m, "Incredible Granite Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2026, 1, 1, 1, 22, 26, 182, DateTimeKind.Local).AddTicks(5649), "The Football Is Good For Training And Recreational Purposes", 8.575795342470034m, 896.61m, "Awesome Frozen Bike" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
