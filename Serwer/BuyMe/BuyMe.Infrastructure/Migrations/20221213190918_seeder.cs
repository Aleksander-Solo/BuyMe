using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuyMe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BooksCategory",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1503), "Fantazy" },
                    { 2, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1538), "Historyczny" },
                    { 3, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1540), "Sci-fi" },
                    { 4, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1541), "Thriller" },
                    { 5, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1543), "Horror" },
                    { 6, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1544), "Biografia i reportaż" },
                    { 7, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1545), "Literatura dziecięca" }
                });

            migrationBuilder.InsertData(
                table: "FilmsCategory",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1679), "Fantazy" },
                    { 2, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1681), "Historyczny" },
                    { 3, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1682), "Sci-fi" },
                    { 4, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1684), "Thriller" },
                    { 5, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1685), "Horror" },
                    { 6, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1686), "Komedia" },
                    { 7, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1687), "Kryminał" },
                    { 8, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1689), "Muzyczny" },
                    { 9, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1690), "Przygodowy" }
                });

            migrationBuilder.InsertData(
                table: "GamesCategory",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1656), "Zręcznościowe" },
                    { 2, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1658), "Przygodowe" },
                    { 3, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1659), "Fabularne" },
                    { 4, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1661), "Strategiczne" },
                    { 5, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1662), "Symulacyjne" },
                    { 6, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1663), "Sportowe" },
                    { 7, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1664), "Edukacyjne" },
                    { 8, new DateTime(2022, 12, 13, 20, 9, 18, 533, DateTimeKind.Local).AddTicks(1666), "Logiczne" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BooksCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BooksCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BooksCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BooksCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BooksCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BooksCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FilmsCategory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GamesCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GamesCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GamesCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GamesCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GamesCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GamesCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GamesCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GamesCategory",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
