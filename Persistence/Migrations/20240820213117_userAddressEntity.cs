using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userAddressEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(9513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 419, DateTimeKind.Local).AddTicks(8993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 954, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 419, DateTimeKind.Local).AddTicks(4979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 954, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 417, DateTimeKind.Local).AddTicks(6932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 952, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(7720)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 955, DateTimeKind.Local).AddTicks(2709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 420, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(8792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 954, DateTimeKind.Local).AddTicks(8559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 419, DateTimeKind.Local).AddTicks(8993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 954, DateTimeKind.Local).AddTicks(4461),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 419, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(4509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 952, DateTimeKind.Local).AddTicks(6075),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 417, DateTimeKind.Local).AddTicks(6932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 19, 1, 15, 3, 953, DateTimeKind.Local).AddTicks(88),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 20, 14, 31, 15, 418, DateTimeKind.Local).AddTicks(961));

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
        }
    }
}
