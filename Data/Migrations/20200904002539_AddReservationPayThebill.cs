using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.Data.Migrations
{
    public partial class AddReservationPayThebill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PayThebill",
                table: "Reservations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayThebill",
                table: "Reservations");
        }
    }
}
