using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class finall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 318, DateTimeKind.Local).AddTicks(6928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 220, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 316, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 317, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 316, DateTimeKind.Local).AddTicks(375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(5869),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 215, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 315, DateTimeKind.Local).AddTicks(6112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 218, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 315, DateTimeKind.Local).AddTicks(1967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 217, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(1346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 313, DateTimeKind.Local).AddTicks(2599),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 212, DateTimeKind.Local).AddTicks(6157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 313, DateTimeKind.Local).AddTicks(6825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 213, DateTimeKind.Local).AddTicks(3255));

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    DatePay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 317, DateTimeKind.Local).AddTicks(7681)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 316, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 316, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 316, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 316, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertTime",
                value: new DateTime(2024, 8, 25, 3, 48, 45, 316, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CatalogItemId",
                table: "OrderItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_CatalogItems_CatalogItemId",
                table: "OrderItems",
                column: "CatalogItemId",
                principalTable: "CatalogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_CatalogItems_CatalogItemId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CatalogItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "CatalogItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 220, DateTimeKind.Local).AddTicks(1370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 318, DateTimeKind.Local).AddTicks(6928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 219, DateTimeKind.Local).AddTicks(2711),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 316, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 215, DateTimeKind.Local).AddTicks(3703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 218, DateTimeKind.Local).AddTicks(2361),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 315, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 217, DateTimeKind.Local).AddTicks(985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 315, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 214, DateTimeKind.Local).AddTicks(1291),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 314, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 212, DateTimeKind.Local).AddTicks(6157),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 313, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 21, 14, 5, 55, 213, DateTimeKind.Local).AddTicks(3255),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 3, 48, 45, 313, DateTimeKind.Local).AddTicks(6825));

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
        }
    }
}
