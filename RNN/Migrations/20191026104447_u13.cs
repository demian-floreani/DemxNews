using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class u13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 17,
                column: "Width",
                value: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 17,
                column: "Width",
                value: 0);
        }
    }
}
