using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class addpinned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsPinned",
                table: "Entries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPinned",
                table: "Entries");
        }
    }
}
