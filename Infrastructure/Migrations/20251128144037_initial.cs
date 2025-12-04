using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CarCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    GarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.GarageId);
                });

            migrationBuilder.CreateTable(
                name: "CarGarage",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarGarage", x => new { x.CarId, x.GarageId });
                    table.ForeignKey(
                        name: "FK_CarGarage_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarGarage_Garages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garages",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarGarage_GarageId",
                table: "CarGarage",
                column: "GarageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarGarage");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Garages");
        }
    }
}
