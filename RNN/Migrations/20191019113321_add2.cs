using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class add2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 18,
                column: "HeadLine",
                value: "MPs debate Boris Johnson's deal as People's Vote march sets off – live news");

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 2, 18 });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 8, 17 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 8, 17 });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 18,
                column: "HeadLine",
                value: "Boris Johnson under fire over row with partner as top Tories raise fears");
        }
    }
}
