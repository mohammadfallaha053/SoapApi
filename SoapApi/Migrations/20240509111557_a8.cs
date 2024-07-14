using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoapApi.Migrations
{
    /// <inheritdoc />
    public partial class a8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MostWanted",
                table: "Soap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Soap",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MostWanted",
                table: "Soap");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Soap");
        }
    }
}
