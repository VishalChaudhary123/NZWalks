using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("68cedbfc-f43f-4f96-870e-41f1296ffd4f"), "Hard" },
                    { new Guid("a7784749-1d36-41b4-9c5c-c7547835af90"), "Easy" },
                    { new Guid("da435085-fa7b-478e-a975-eea82c2cbde6"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0541fd0d-403e-4783-95d2-877848f49773"), "Wellington", "WGN", "https://th.bing.com/th/id/OIP.58LIsvmhTiieG_6pTm7FIAHaE8?rs=1&pid=ImgDetMain" },
                    { new Guid("0922d3ca-37df-44e0-8874-297ffdde3399"), "Auckland", "AKL", "https://www.distantjourneys.co.uk/wp-content/uploads/2018/03/auckland-sky-tower-at-night-new-zealand.jpg" },
                    { new Guid("56ecd709-dc48-4ad0-ae72-db687141244d"), "Northland", "NTL", "https://www.civitatis.com/f/australia/byron-bay/byron-bay-m.jpg" },
                    { new Guid("7b8308d4-2cae-4658-873f-b43435504e7b"), "Bey of Plenty", "BOP", "https://lp-cms-production.imgix.net/image_browser/GettyImages-103581610.jpg?auto=format&fit=crop&sharp=10&vib=20&ixlib=react-8.6.4&w=850&q=20&dpr=5" },
                    { new Guid("80853b49-c740-4a7a-9a0b-bbf8d07be58e"), "Southland", "STL", "https://th.bing.com/th/id/OIP.9O3-I4uO5XgoQ9QmGIKi6QHaEK?rs=1&pid=ImgDetMain" },
                    { new Guid("f6605d3f-0269-46d8-a023-a12a20810b6d"), "Nelson", "NSN", "https://th.bing.com/th/id/OIP.FRYxO84ju7dLdC8ymUSCpwHaEK?rs=1&pid=ImgDetMain" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("68cedbfc-f43f-4f96-870e-41f1296ffd4f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a7784749-1d36-41b4-9c5c-c7547835af90"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("da435085-fa7b-478e-a975-eea82c2cbde6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0541fd0d-403e-4783-95d2-877848f49773"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0922d3ca-37df-44e0-8874-297ffdde3399"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("56ecd709-dc48-4ad0-ae72-db687141244d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7b8308d4-2cae-4658-873f-b43435504e7b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("80853b49-c740-4a7a-9a0b-bbf8d07be58e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f6605d3f-0269-46d8-a023-a12a20810b6d"));
        }
    }
}
