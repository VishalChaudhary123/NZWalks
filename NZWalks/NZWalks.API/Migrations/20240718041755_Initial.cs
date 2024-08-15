using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0541fd0d-403e-4783-95d2-877848f49773"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "WGN", "Wellington" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0922d3ca-37df-44e0-8874-297ffdde3399"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "AKL", "Auckland" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("56ecd709-dc48-4ad0-ae72-db687141244d"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "NTL", "Northland" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7b8308d4-2cae-4658-873f-b43435504e7b"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "BOP", "Bey of Plenty" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("80853b49-c740-4a7a-9a0b-bbf8d07be58e"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "STL", "Southland" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f6605d3f-0269-46d8-a023-a12a20810b6d"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "NSN", "Nelson" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0541fd0d-403e-4783-95d2-877848f49773"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "Wellington", "WGN" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0922d3ca-37df-44e0-8874-297ffdde3399"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "Auckland", "AKL" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("56ecd709-dc48-4ad0-ae72-db687141244d"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "Northland", "NTL" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7b8308d4-2cae-4658-873f-b43435504e7b"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "Bey of Plenty", "BOP" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("80853b49-c740-4a7a-9a0b-bbf8d07be58e"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "Southland", "STL" });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f6605d3f-0269-46d8-a023-a12a20810b6d"),
                columns: new[] { "Code", "Name" },
                values: new object[] { "Nelson", "NSN" });
        }
    }
}
