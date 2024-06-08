using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    public partial class add_carreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarReservation",
                columns: table => new
                {
                    CarReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakeCar = table.Column<int>(type: "int", nullable: false),
                    DropCar = table.Column<int>(type: "int", nullable: false),
                    TakeCarDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropCarDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReservation", x => x.CarReservationId);
                    table.ForeignKey(
                        name: "FK_CarReservation_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarReservation_CarId",
                table: "CarReservation",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarReservation");
        }
    }
}
