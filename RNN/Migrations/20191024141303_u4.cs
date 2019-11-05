using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class u4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 13,
                column: "TitleId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 13,
                column: "TitleId",
                value: 2);
        }
    }
}
