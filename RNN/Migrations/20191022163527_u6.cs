using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class u6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 8, 15 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 29, 22 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 14 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 19 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 30, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 31, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 33, 10 });

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "HeadLine", "IsFeatured" },
                values: new object[] { "Opinion piece 4", false });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "HeadLine", "IsFeatured" },
                values: new object[] { "Opinion piece 5", false });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "HeadLine", "IsFeatured" },
                values: new object[] { "Opinion piece 6", false });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 20,
                column: "HeadLine",
                value: "Opinion piece 7");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 1,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 1");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 2,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 2");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 3,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 3");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 4,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 4");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 5,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 5");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 6,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 6");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 7,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 7");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 8,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 8");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 9,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 9");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 10,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 10");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 11,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 11");

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AuthorId", "Body", "Date", "Discriminator", "GroupingId", "HeadLine", "Img", "IsFeatured", "Paragraph", "TitleId", "Url" },
                values: new object[,]
                {
                    { 15, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", null, "Opinion piece 2", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null },
                    { 12, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial", null, "Boris Johnson under fire over row with partner as top Tories raise fears", "editorial.jpg", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 1, "" },
                    { 13, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial", null, "MPs debate Boris Johnson's deal as People's Vote march sets off – live news", "editorial.jpg", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 2, "" },
                    { 16, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", null, "Opinion piece 3", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null },
                    { 14, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", null, "Opinion piece 1", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 5 },
                    { 1, 20 },
                    { 3, 3 },
                    { 7, 19 },
                    { 6, 18 },
                    { 5, 17 },
                    { 4, 11 },
                    { 3, 10 },
                    { 2, 9 },
                    { 1, 8 },
                    { 7, 7 },
                    { 6, 6 },
                    { 4, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Autho1");

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Grouping 1");

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Grouping 2");

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Grouping 3");

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Grouping 4");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Topic 1");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Topic 2");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Topic 3");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Topic 4");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Topic 5");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Topic 6");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Topic 7");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Topic 8");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Topic 9");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Topic 10");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Topic 11");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Topic 12");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Topic 13");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Topic 14");

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 1, 12 },
                    { 2, 13 },
                    { 1, 14 },
                    { 2, 14 },
                    { 3, 15 },
                    { 4, 16 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 5, 17 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 6, 18 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "ArticleToTopics",
                keyColumns: new[] { "TopicId", "ArticleId" },
                keyValues: new object[] { 7, 19 });

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "HeadLine", "IsFeatured" },
                values: new object[] { "Opinion piece 1", true });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "HeadLine", "IsFeatured" },
                values: new object[] { "Opinion piece 2", true });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "HeadLine", "IsFeatured" },
                values: new object[] { "Opinion piece 3", true });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 20,
                column: "HeadLine",
                value: "Opinion piece 4");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 1,
                column: "HeadLine",
                value: "Journalists Detained During First Day of Bilderberg");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 2,
                column: "HeadLine",
                value: "RON PAUL: US/UK Trying To Kill Assange?");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 3,
                column: "HeadLine",
                value: "Merkel Attacks Trump in Harvard Speech");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 4,
                column: "HeadLine",
                value: "Bye-bye Bolton?");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 5,
                column: "HeadLine",
                value: "White House launches tool to report censorship on Facebook");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 6,
                column: "HeadLine",
                value: "Donald Trump: 'I Got Me Elected'");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 7,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 1");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 8,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 2");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 9,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 3");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 10,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 4");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 11,
                column: "HeadLine",
                value: "Test post: put all the content here for the post title 5");

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AuthorId", "Body", "Date", "Discriminator", "GroupingId", "HeadLine", "Img", "IsFeatured", "Paragraph", "TitleId", "Url" },
                values: new object[,]
                {
                    { 12, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", null, "Test post: put all the content here for the post title 6", null, true, null, null, "" },
                    { 21, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", null, "Opinion piece 5", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null },
                    { 14, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", null, "Test post: put all the content here for the post title 8", null, true, null, null, "" },
                    { 22, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", null, "Opinion piece 6", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null },
                    { 13, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", null, "Test post: put all the content here for the post title 7", null, true, null, null, "" },
                    { 16, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial", null, "MPs debate Boris Johnson's deal as People's Vote march sets off – live news", "editorial.jpg", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 2, "" },
                    { 15, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial", null, "Boris Johnson under fire over row with partner as top Tories raise fears", "editorial.jpg", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 1, "" },
                    { 23, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", null, "Opinion piece 7", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, null }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 2, 17 },
                    { 2, 11 },
                    { 5, 6 },
                    { 8, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "RenegadeNews");

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Migrant Crisis");

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Boom & Bust");

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Climate Activism");

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Free Speech");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Brexit");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Deep State");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Corruption");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Money in Politics");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Donald Trump");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "EU");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Neo-Liberalism");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Bilderberg");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Federal Reserve");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "NWO");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Migrants");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Mass Immigration");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Islamism");

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Assange");

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 31, "Junker" },
                    { 30, "Salvini" },
                    { 29, "Viktor Orban" },
                    { 28, "Wikipedia" },
                    { 27, "Big Brother" },
                    { 26, "First Amendment" },
                    { 25, "Tech Fascism" },
                    { 24, "Censorship" },
                    { 17, "RINOs" },
                    { 22, "5G" },
                    { 21, "GMO" },
                    { 20, "Animal Rights" },
                    { 19, "Economy" },
                    { 18, "Crony Capitalism" },
                    { 32, "Refugees" },
                    { 16, "Neo-Cons" },
                    { 15, "Merkel" },
                    { 23, "Wifi" },
                    { 33, "Integration" }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 8, 15 },
                    { 30, 20 },
                    { 30, 19 },
                    { 30, 18 },
                    { 30, 17 },
                    { 30, 14 },
                    { 30, 13 },
                    { 30, 12 },
                    { 31, 9 },
                    { 30, 8 },
                    { 29, 7 },
                    { 29, 5 },
                    { 16, 4 },
                    { 15, 3 },
                    { 5, 23 },
                    { 2, 21 },
                    { 2, 16 },
                    { 29, 22 },
                    { 33, 10 }
                });
        }
    }
}
