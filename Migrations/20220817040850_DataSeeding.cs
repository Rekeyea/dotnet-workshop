using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workshop.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Clients_ClientId",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "IsDeleted", "ModifiedTime", "Name", "Surname" },
                values: new object[] { 1L, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7650), null, false, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7650), "Emi", "Con" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ClientId", "CreatedTime", "DeletedTime", "Description", "IsDeleted", "ModifiedTime", "Name", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7310), null, "Desc Prod 1", false, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7350), "Prod 1", 1000m },
                    { 2L, 1L, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7360), null, "Desc Prod 2", false, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7360), "Prod 2", 1300m },
                    { 3L, 1L, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7360), null, "Desc Prod 3", false, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7360), "Prod 3", 100m },
                    { 4L, 1L, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370), null, "Desc Prod 4", false, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370), "Prod 4", 100.4m },
                    { 5L, 1L, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370), null, "Desc Prod 5", false, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370), "Prod 5", 2030.50m },
                    { 6L, 1L, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370), null, "Desc Prod 6", false, new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370), "Prod 6", 2000m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Clients_ClientId",
                table: "Products",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Clients_ClientId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "Products",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Clients_ClientId",
                table: "Products",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
