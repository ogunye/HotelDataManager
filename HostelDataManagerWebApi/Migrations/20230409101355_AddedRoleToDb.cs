using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HostelDataManagerWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoleToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "136a5afb-e4d9-4b52-9375-73c02612d9ef", null, "Administrator", "ADMINISTRATOR" },
                    { "d398283e-a4c5-4620-ae18-88e2016aa464", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "136a5afb-e4d9-4b52-9375-73c02612d9ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d398283e-a4c5-4620-ae18-88e2016aa464");
        }
    }
}
