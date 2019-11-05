using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class u12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 17,
                column: "Rank",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 18,
                column: "Rank",
                value: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 17,
                column: "Rank",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 18,
                column: "Rank",
                value: 6);
        }
    }
}
