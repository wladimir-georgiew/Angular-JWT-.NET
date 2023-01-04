using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtCave.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialRolesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12eb5348-bc9f-40ba-a17b-52434ce6f4c6", "e4e02cc2-6424-4505-8926-143919b01dac", "Admin", "ADMIN" },
                    { "19f9e873-38ca-4c00-92d6-84090c73715c", "13901cf8-12de-475d-8527-e4c1dcf45f81", "Customer", "CUSTOMER" },
                    { "d9924e85-fc63-4a6b-adb7-f762e5db4202", "dd9f77ae-76df-48a8-854e-be22bae87e55", "FreeUser", "FREEUSER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12eb5348-bc9f-40ba-a17b-52434ce6f4c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19f9e873-38ca-4c00-92d6-84090c73715c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9924e85-fc63-4a6b-adb7-f762e5db4202");
        }
    }
}
