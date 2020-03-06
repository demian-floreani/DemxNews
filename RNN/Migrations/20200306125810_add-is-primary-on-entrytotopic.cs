using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class addisprimaryonentrytotopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "EntryToTopics",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "EntryToTopics");
        }
    }
}
