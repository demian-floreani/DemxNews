using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 29, 5 });

            migrationBuilder.UpdateData(
                table: "Editorials",
                keyColumn: "Id",
                keyValue: 1,
                column: "Img",
                value: "editorial.jpg");

            migrationBuilder.InsertData(
                table: "OpinionToTopic",
                columns: new[] { "TopicId", "OpinionId" },
                values: new object[,]
                {
                    { 30, 1 },
                    { 30, 2 },
                    { 30, 3 },
                    { 2, 5 },
                    { 29, 6 },
                    { 5, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Opinion piece 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 29, 6 });

            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 30, 1 });

            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "OpinionToTopic",
                keyColumns: new[] { "TopicId", "OpinionId" },
                keyValues: new object[] { 30, 3 });

            migrationBuilder.UpdateData(
                table: "Editorials",
                keyColumn: "Id",
                keyValue: 1,
                column: "Img",
                value: "");

            migrationBuilder.InsertData(
                table: "OpinionToTopic",
                columns: new[] { "TopicId", "OpinionId" },
                values: new object[,]
                {
                    { 29, 5 },
                    { 5, 6 },
                    { 2, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "How the Right Must Embrace Environmen- talism");
        }
    }
}
