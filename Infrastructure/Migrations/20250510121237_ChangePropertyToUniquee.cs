using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyToUniquee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_airports_code",
                table: "airports",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_air_crafts_registration_number",
                table: "air_crafts",
                column: "registration_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_airports_code",
                table: "airports");

            migrationBuilder.DropIndex(
                name: "ix_air_crafts_registration_number",
                table: "air_crafts");
        }
    }
}
