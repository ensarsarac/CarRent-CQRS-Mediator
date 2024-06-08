using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Migrations
{
    public partial class add_carreservation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservation_Cars_CarId",
                table: "CarReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarReservation",
                table: "CarReservation");

            migrationBuilder.RenameTable(
                name: "CarReservation",
                newName: "CarReservations");

            migrationBuilder.RenameColumn(
                name: "TakeCar",
                table: "CarReservations",
                newName: "TakeCarId");

            migrationBuilder.RenameColumn(
                name: "DropCar",
                table: "CarReservations",
                newName: "DropCarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarReservation_CarId",
                table: "CarReservations",
                newName: "IX_CarReservations_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarReservations",
                table: "CarReservations",
                column: "CarReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_DropCarId",
                table: "CarReservations",
                column: "DropCarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_TakeCarId",
                table: "CarReservations",
                column: "TakeCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservations_Cars_CarId",
                table: "CarReservations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservations_Locations_DropCarId",
                table: "CarReservations",
                column: "DropCarId",
                principalTable: "Locations",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservations_Locations_TakeCarId",
                table: "CarReservations",
                column: "TakeCarId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservations_Cars_CarId",
                table: "CarReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_CarReservations_Locations_DropCarId",
                table: "CarReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_CarReservations_Locations_TakeCarId",
                table: "CarReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarReservations",
                table: "CarReservations");

            migrationBuilder.DropIndex(
                name: "IX_CarReservations_DropCarId",
                table: "CarReservations");

            migrationBuilder.DropIndex(
                name: "IX_CarReservations_TakeCarId",
                table: "CarReservations");

            migrationBuilder.RenameTable(
                name: "CarReservations",
                newName: "CarReservation");

            migrationBuilder.RenameColumn(
                name: "TakeCarId",
                table: "CarReservation",
                newName: "TakeCar");

            migrationBuilder.RenameColumn(
                name: "DropCarId",
                table: "CarReservation",
                newName: "DropCar");

            migrationBuilder.RenameIndex(
                name: "IX_CarReservations_CarId",
                table: "CarReservation",
                newName: "IX_CarReservation_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarReservation",
                table: "CarReservation",
                column: "CarReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservation_Cars_CarId",
                table: "CarReservation",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
