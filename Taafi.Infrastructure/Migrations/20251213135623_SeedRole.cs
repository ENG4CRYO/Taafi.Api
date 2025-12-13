using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taafi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table:"AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[,]
                {
                    { "1", AspRoles.Admin, AspRoles.Admin.ToUpper(), Guid.NewGuid().ToString() },
                    { "2", AspRoles.User, AspRoles.User.ToUpper(), Guid.NewGuid().ToString() }
                }
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData
                (table:"AspNetRoles",
                keyColumn:"Id",
                keyValue:new object[] {"1", "2"}
                );

        }
    }
}
