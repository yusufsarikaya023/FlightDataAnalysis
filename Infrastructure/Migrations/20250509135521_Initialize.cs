using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "air_crafts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    registration_number = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    aircraft_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_air_crafts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "airports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_airports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flight_number = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    air_craft_id = table.Column<int>(type: "integer", nullable: false),
                    departure_airport_id = table.Column<int>(type: "integer", nullable: false),
                    arrival_airport_id = table.Column<int>(type: "integer", nullable: false),
                    departure_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    arrival_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flights", x => x.id);
                    table.ForeignKey(
                        name: "fk_flights_air_crafts_air_craft_id",
                        column: x => x.air_craft_id,
                        principalTable: "air_crafts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_flights_airports_arrival_airport_id",
                        column: x => x.arrival_airport_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_flights_airports_departure_airport_id",
                        column: x => x.departure_airport_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_flights_air_craft_id",
                table: "flights",
                column: "air_craft_id");

            migrationBuilder.CreateIndex(
                name: "ix_flights_arrival_airport_id",
                table: "flights",
                column: "arrival_airport_id");

            migrationBuilder.CreateIndex(
                name: "ix_flights_departure_airport_id",
                table: "flights",
                column: "departure_airport_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropTable(
                name: "air_crafts");

            migrationBuilder.DropTable(
                name: "airports");
        }
    }
}
