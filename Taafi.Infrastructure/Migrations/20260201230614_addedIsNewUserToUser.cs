using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taafi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedIsNewUserToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNewUser",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNewUser",
                table: "AspNetUsers");
        }
    }
}
