using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLDVwebApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameVenueIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueID",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "Events",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_VenueID",
                table: "Events",
                newName: "IX_Events_VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Events",
                newName: "VenueID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                newName: "IX_Events_VenueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueID",
                table: "Events",
                column: "VenueID",
                principalTable: "Venues",
                principalColumn: "VenueId");
        }
    }
}
