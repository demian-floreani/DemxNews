using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class up4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 25 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 8, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 19, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 31, 11 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 33, 12 });

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "HeadLine", "TitleId" },
                values: new object[] { "MPs debate Boris Johnson's deal as People's Vote march sets off – live news", 2 });

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

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 7,
                column: "HeadLine",
                value: "Donald Trump: 'I Got Me Elected'");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 8,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 1");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 9,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 2");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 10,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 3");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 11,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 4");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 12,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 5");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 13,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 6");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 14,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 7");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 15,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 8");

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AuthorId", "Body", "Date", "Discriminator", "GroupingId", "HeadLine", "Img", "IsFeatured", "Paragraph", "TitleId", "Url" },
                values: new object[,]
                {
                    { 16, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial", null, "Boris Johnson under fire over row with partner as top Tories raise fears", "editorial.jpg", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 1, "" },
                    { 18, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", null, "Opinion piece 1", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 5, 24 },
                    { 29, 23 },
                    { 2, 22 },
                    { 2, 17 },
                    { 30, 13 },
                    { 2, 12 },
                    { 33, 11 },
                    { 31, 10 },
                    { 30, 9 },
                    { 29, 8 },
                    { 5, 7 }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 8, 16 });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 30, 18 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 24 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 8, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 31, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 33, 11 });

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "HeadLine", "TitleId" },
                values: new object[] { "Boris Johnson under fire over row with partner as top Tories raise fears", 1 });

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

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 7,
                column: "HeadLine",
                value: "U.S. Economy Grew 3.1% in First Quarter");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 8,
                column: "HeadLine",
                value: "Donald Trump: 'I Got Me Elected'");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 9,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 1");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 10,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 2");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 11,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 3");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 12,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 4");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 13,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 5");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 14,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 6");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 15,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 7");

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AuthorId", "Body", "Date", "Discriminator", "GroupingId", "HeadLine", "Img", "IsFeatured", "Paragraph", "TitleId", "Url" },
                values: new object[,]
                {
                    { 25, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", null, "Opinion piece 7", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null },
                    { 16, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", null, "Test post: put all the content here for the post title 8", null, true, null, null, "" },
                    { 18, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial", null, "MPs debate Boris Johnson's deal as People's Vote march sets off – live news", "editorial.jpg", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 2, "" }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 29, 24 },
                    { 2, 23 },
                    { 30, 22 },
                    { 2, 19 },
                    { 8, 17 },
                    { 2, 13 },
                    { 33, 12 },
                    { 31, 11 },
                    { 30, 10 },
                    { 29, 9 },
                    { 5, 8 },
                    { 19, 7 }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 5, 25 });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[] { 30, 16 });
        }
    }
}
