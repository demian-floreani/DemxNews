using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Renegade News" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Topic 1" },
                    { 2, "Topic 2" },
                    { 3, "Topic 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
