using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class u14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Rank", "Width" },
                values: new object[] { 1, 12 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Rank", "Width" },
                values: new object[] { 2, 8 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Rank", "Width" },
                values: new object[] { 2, 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Rank", "Width" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Rank", "Width" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Rank", "Width" },
                values: new object[] { 0, 0 });
        }
    }
}
