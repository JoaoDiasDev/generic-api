using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace joaodiasgenericapi.Migrations
{
    /// <inheritdoc />
    public partial class addcoinsvariation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Variation",
                table: "Coins",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Variation",
                table: "Coins");
        }
    }
}
