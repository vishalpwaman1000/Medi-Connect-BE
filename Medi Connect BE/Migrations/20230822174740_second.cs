using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medi_Connect_BE.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSuccess",
                table: "UserDetails",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "UserDetails",
                newName: "IsSuccess");
        }
    }
}
