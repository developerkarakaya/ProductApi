using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(421), false, "Jewelery & Kids" },
                    { 2, new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(5454), false, "Sports" },
                    { 3, new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(5605), false, "Games" },
                    { 4, new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(5732), false, "Outdoors & Movies" },
                    { 5, new DateTime(2026, 1, 1, 1, 22, 26, 170, DateTimeKind.Local).AddTicks(5985), false, "Music, Sports & Clothing" },
                    { 6, new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(456), false, "Outdoors & Jewelery" },
                    { 7, new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(1614), false, "Books & Kids" },
                    { 8, new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(1853), false, "Electronics" },
                    { 9, new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(1947), false, "Tools & Books" },
                    { 10, new DateTime(2026, 1, 1, 1, 22, 26, 171, DateTimeKind.Local).AddTicks(2054), false, "Computers" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 1, 22, 26, 172, DateTimeKind.Local).AddTicks(9199), false, "Elektronik", 0, 1 },
                    { 2, new DateTime(2026, 1, 1, 1, 22, 26, 172, DateTimeKind.Local).AddTicks(9206), false, "Moda", 0, 2 },
                    { 3, new DateTime(2026, 1, 1, 1, 22, 26, 172, DateTimeKind.Local).AddTicks(9209), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2026, 1, 1, 1, 22, 26, 172, DateTimeKind.Local).AddTicks(9211), false, "Kadın", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 1, 22, 26, 175, DateTimeKind.Local).AddTicks(3477), "The Football Is Good For Training And Recreational Purposes", false, "Ergonomic Granite Ball" },
                    { 2, 3, new DateTime(2026, 1, 1, 1, 22, 26, 175, DateTimeKind.Local).AddTicks(3531), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", false, "Ergonomic Concrete Bike" },
                    { 3, 4, new DateTime(2026, 1, 1, 1, 22, 26, 175, DateTimeKind.Local).AddTicks(3559), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", true, "Handmade Rubber Keyboard" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 1, 22, 26, 182, DateTimeKind.Local).AddTicks(5000), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 4.602938602861063m, false, 216.06m, "Incredible Granite Tuna" },
                    { 2, 3, new DateTime(2026, 1, 1, 1, 22, 26, 182, DateTimeKind.Local).AddTicks(5649), "The Football Is Good For Training And Recreational Purposes", 8.575795342470034m, false, 896.61m, "Awesome Frozen Bike" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
