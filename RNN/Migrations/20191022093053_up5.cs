using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class up5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 2, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 6 });
        }
    }
}
