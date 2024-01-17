using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZone2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderCityId = table.Column<int>(type: "int", nullable: false),
                    AddressSender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientCityId = table.Column<int>(type: "int", nullable: false),
                    AddressRecipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "DistrictId", "Name", "Prefix", "RegionId", "TimeZone", "TimeZone2", "Tz" },
                values: new object[] { 1, 1, "Москва", "Moskva", 2, "+4:00", "+5:00", "Europe/Moscow" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressRecipient", "AddressSender", "Data", "RecipientCityId", "SenderCityId", "Weight" },
                values: new object[] { 1, "Ул Братьев Сизых 11", "Ул Калашникова д3", new DateTime(2024, 1, 17, 11, 31, 54, 701, DateTimeKind.Local).AddTicks(5420), 1, 2, 24.600000000000001 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
