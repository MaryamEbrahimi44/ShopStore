using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Basket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 952, DateTimeKind.Local).AddTicks(6075)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CatalogTypeId = table.Column<int>(type: "int", nullable: false),
                    CatalogBrandId = table.Column<int>(type: "int", nullable: false),
                    AvailableStock = table.Column<int>(type: "int", nullable: false),
                    RestockThreshold = table.Column<int>(type: "int", nullable: false),
                    MaxStockThreshold = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(8792)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(88)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 954, DateTimeKind.Local).AddTicks(4461)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItemFeature_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 954, DateTimeKind.Local).AddTicks(8559)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItemImage_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CatalogItemId",
                table: "BasketItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemFeature_CatalogItemId",
                table: "CatalogItemFeature",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemImage_CatalogItemId",
                table: "CatalogItemImage",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogBrandId",
                table: "CatalogItems",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogTypeId",
                table: "CatalogItems",
                column: "CatalogTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "CatalogItemFeature");

            migrationBuilder.DropTable(
                name: "CatalogItemImage");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "CatalogItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(9071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(5077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 14, 14, 8, 31, 48, DateTimeKind.Local).AddTicks(9071));
        }
    }
}
