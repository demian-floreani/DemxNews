using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class up3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 25, 5 });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 29, 5 });

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Migrant Crisis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 5 });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 25, 5 });

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Migration");
        }
    }
}
