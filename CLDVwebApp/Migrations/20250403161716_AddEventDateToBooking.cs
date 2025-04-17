using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLDVwebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddEventDateToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Venues_VenueID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "Venues",
                newName: "VenueId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Events",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "Bookings",
                newName: "VenueId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Bookings",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Bookings",
                newName: "BookingId");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "Bookings",
                newName: "EventDate");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_VenueID_EventID",
                table: "Bookings",
                newName: "IX_Bookings_VenueId_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_EventID",
                table: "Bookings",
                newName: "IX_Bookings_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Venues_VenueId",
                table: "Bookings",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Venues_VenueId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Venues",
                newName: "VenueID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Bookings",
                newName: "VenueID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Bookings",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "BookingID");

            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "Bookings",
                newName: "BookingDate");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_VenueId_EventId",
                table: "Bookings",
                newName: "IX_Bookings_VenueID_EventID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_EventId",
                table: "Bookings",
                newName: "IX_Bookings_EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventID",
                table: "Bookings",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Venues_VenueID",
                table: "Bookings",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "VenueID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
