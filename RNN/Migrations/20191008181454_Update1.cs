using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostToTopics",
                keyColumns: new[] { "TopicId", "PostId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "PostToTopics",
                keyColumns: new[] { "TopicId", "PostId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "PostToTopics",
                keyColumns: new[] { "TopicId", "PostId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.InsertData(
                table: "PostToTopics",
                columns: new[] { "TopicId", "PostId" },
                values: new object[] { 30, 14 });

            migrationBuilder.InsertData(
                table: "PostToTopics",
                columns: new[] { "TopicId", "PostId" },
                values: new object[] { 30, 15 });

            migrationBuilder.InsertData(
                table: "PostToTopics",
                columns: new[] { "TopicId", "PostId" },
                values: new object[] { 30, 16 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostToTopics",
                keyColumns: new[] { "TopicId", "PostId" },
                keyValues: new object[] { 30, 14 });

            migrationBuilder.DeleteData(
                table: "PostToTopics",
                keyColumns: new[] { "TopicId", "PostId" },
                keyValues: new object[] { 30, 15 });

            migrationBuilder.DeleteData(
                table: "PostToTopics",
                keyColumns: new[] { "TopicId", "PostId" },
                keyValues: new object[] { 30, 16 });

            migrationBuilder.InsertData(
                table: "PostToTopics",
                columns: new[] { "TopicId", "PostId" },
                values: new object[] { 2, 14 });

            migrationBuilder.InsertData(
                table: "PostToTopics",
                columns: new[] { "TopicId", "PostId" },
                values: new object[] { 2, 15 });

            migrationBuilder.InsertData(
                table: "PostToTopics",
                columns: new[] { "TopicId", "PostId" },
                values: new object[] { 2, 16 });
        }
    }
}
