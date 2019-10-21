using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class neweditorial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 18 });

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 19,
                column: "HeadLine",
                value: "Opinion piece 1");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 20,
                column: "HeadLine",
                value: "Opinion piece 2");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "HeadLine", "IsFeatured" },
                values: new object[] { "Opinion piece 3", true });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 22,
                column: "HeadLine",
                value: "Opinion piece 4");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 23,
                column: "HeadLine",
                value: "Opinion piece 5");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 24,
                column: "HeadLine",
                value: "Opinion piece 6");

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AuthorId", "Body", "Date", "Discriminator", "HeadLine", "Img", "IsFeatured", "Paragraph", "TitleId", "Url" },
                values: new object[,]
                {
                    { 18, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial", "Boris Johnson under fire over row with partner as top Tories raise fears", "editorial.jpg", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 2, "" },
                    { 25, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 7", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 30, 22 },
                    { 2, 23 },
                    { 29, 24 }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 5, 25 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 22 });

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 19,
                column: "HeadLine",
                value: "Opinion piece 2");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 20,
                column: "HeadLine",
                value: "Opinion piece 3");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "HeadLine", "IsFeatured" },
                values: new object[] { "Opinion piece 4", false });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 22,
                column: "HeadLine",
                value: "Opinion piece 5");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 23,
                column: "HeadLine",
                value: "Opinion piece 6");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 24,
                column: "HeadLine",
                value: "Opinion piece 7");

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AuthorId", "Body", "Date", "Discriminator", "HeadLine", "Img", "IsFeatured", "Paragraph", "TitleId", "Url" },
                values: new object[] { 18, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 1", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 2, 22 },
                    { 29, 23 },
                    { 5, 24 }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 30, 18 });
        }
    }
}
