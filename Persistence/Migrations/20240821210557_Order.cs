using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 220, DateTimeKind.Local).AddTicks(1370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 215, DateTimeKind.Local).AddTicks(3703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 218, DateTimeKind.Local).AddTicks(2361),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 419, DateTimeKind.Local).AddTicks(8993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 217, DateTimeKind.Local).AddTicks(985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 419, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 212, DateTimeKind.Local).AddTicks(6157),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 417, DateTimeKind.Local).AddTicks(6932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 213, DateTimeKind.Local).AddTicks(3255),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(961));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_UserId = table.Column<int>(type: "int", nullable: false),
                    Address_ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(7720),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 220, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(9513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 215, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 419, DateTimeKind.Local).AddTicks(8993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 218, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 419, DateTimeKind.Local).AddTicks(4979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 217, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 417, DateTimeKind.Local).AddTicks(6932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 212, DateTimeKind.Local).AddTicks(6157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 213, DateTimeKind.Local).AddTicks(3255));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508));
        }
    }
}
