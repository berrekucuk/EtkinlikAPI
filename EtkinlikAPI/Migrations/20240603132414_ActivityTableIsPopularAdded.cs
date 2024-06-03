using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtkinlikAPI.Migrations
{
    /// <inheritdoc />
    public partial class ActivityTableIsPopularAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Activities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Activities");
        }
    }
}
