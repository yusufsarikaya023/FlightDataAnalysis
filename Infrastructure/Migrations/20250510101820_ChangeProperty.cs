using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "departure_time",
                table: "flights",
                newName: "departure_date_time");

            migrationBuilder.RenameColumn(
                name: "arrival_time",
                table: "flights",
                newName: "arrival_date_time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "departure_date_time",
                table: "flights",
                newName: "departure_time");

            migrationBuilder.RenameColumn(
                name: "arrival_date_time",
                table: "flights",
                newName: "arrival_time");
        }
    }
}
