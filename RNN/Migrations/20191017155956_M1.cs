using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleId = table.Column<int>(nullable: true),
                    HeadLine = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Paragraph = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectToTopics",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectToTopics", x => new { x.SubjectId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_SubjectToTopics_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectToTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleToTopics",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleToTopics", x => new { x.TopicId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleToTopics_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleToTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AuthorId", "Body", "Date", "Discriminator", "HeadLine", "Img", "IsFeatured", "Paragraph", "TitleId", "Url" },
                values: new object[,]
                {
                    { 9, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Test post: put all the content here for the post title 1", null, true, null, null, "" },
                    { 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Journalists Detained During First Day of Bilderberg", null, true, null, null, "" },
                    { 2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "RON PAUL: US/UK Trying To Kill Assange?", null, true, null, null, "" },
                    { 3, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Merkel Attacks Trump in Harvard Speech", null, true, null, null, "" },
                    { 4, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Bye-bye Bolton?", null, true, null, null, "" },
                    { 5, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "White House launches tool to report censorship on Facebook", null, true, null, null, "" },
                    { 6, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Barr: Mueller could have reached a decision on obstruction", null, true, null, null, "" },
                    { 7, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "U.S. Economy Grew 3.1% in First Quarter", null, true, null, null, "" },
                    { 8, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Donald Trump: 'I Got Me Elected'", null, true, null, null, "" },
                    { 16, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Test post: put all the content here for the post title 8", null, true, null, null, "" },
                    { 10, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Test post: put all the content here for the post title 2", null, true, null, null, "" },
                    { 11, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Test post: put all the content here for the post title 3", null, true, null, null, "" },
                    { 12, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Test post: put all the content here for the post title 4", null, true, null, null, "" },
                    { 13, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Test post: put all the content here for the post title 5", null, true, null, null, "" },
                    { 14, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Test post: put all the content here for the post title 6", null, true, null, null, "" },
                    { 15, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Post", "Test post: put all the content here for the post title 7", null, true, null, null, "" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "RenegadeNews" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "Rank" },
                values: new object[,]
                {
                    { 5, "Deep State", 5 },
                    { 3, "Climate Activism", 3 },
                    { 4, "Free Speech", 4 },
                    { 1, "Migration", 1 },
                    { 2, "Boom & Bust", 2 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Editorial" },
                    { 2, "Opinion" },
                    { 3, "UK News" },
                    { 4, "UK Politics" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 18, "Crony Capitalism" },
                    { 19, "Economy" },
                    { 20, "Animal Rights" },
                    { 21, "GMO" },
                    { 22, "5G" },
                    { 23, "Wifi" },
                    { 24, "Censorship" },
                    { 27, "Big Brother" },
                    { 26, "First Amendment" },
                    { 28, "Wikipedia" },
                    { 29, "Viktor Orban" },
                    { 30, "Salvini" },
                    { 31, "Junker" },
                    { 25, "Tech Fascism" },
                    { 17, "RINOs" },
                    { 4, "Money in Politics" },
                    { 15, "Merkel" },
                    { 1, "Brexit" },
                    { 2, "Deep State" },
                    { 3, "Corruption" },
                    { 32, "Refugees" },
                    { 5, "Donald Trump" },
                    { 6, "EU" },
                    { 16, "Neo-Cons" },
                    { 7, "Neo-Liberalism" },
                    { 9, "Federal Reserve" },
                    { 10, "NWO" },
                    { 11, "Migrants" },
                    { 12, "Mass Immigration" },
                    { 13, "Islamism" },
                    { 14, "Assange" },
                    { 8, "Bilderberg" },
                    { 33, "Integration" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AuthorId", "Body", "Date", "Discriminator", "HeadLine", "Img", "IsFeatured", "Paragraph", "TitleId", "Url" },
                values: new object[,]
                {
                    { 18, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 1", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", null, null },
                    { 19, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 2", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", null, null },
                    { 20, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 3", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", null, null },
                    { 21, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 4", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", null, null },
                    { 22, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 5", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", null, null },
                    { 23, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 6", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", null, null },
                    { 24, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opinion", "Opinion piece 7", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", null, null },
                    { 17, 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial", "Boris Johnson under fire over row with partner as top Tories raise fears", "editorial.jpg", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 1, "" }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 30, 16 },
                    { 30, 15 },
                    { 30, 14 },
                    { 30, 10 },
                    { 29, 9 },
                    { 25, 5 },
                    { 8, 1 },
                    { 16, 4 },
                    { 15, 3 },
                    { 31, 11 },
                    { 5, 8 },
                    { 2, 13 },
                    { 2, 2 },
                    { 19, 7 },
                    { 33, 12 }
                });

            migrationBuilder.InsertData(
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" },
                values: new object[,]
                {
                    { 30, 18 },
                    { 30, 19 },
                    { 30, 20 },
                    { 30, 21 },
                    { 2, 22 },
                    { 29, 23 },
                    { 5, 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_AuthorId",
                table: "Article",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_TitleId",
                table: "Article",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleToTopics_ArticleId",
                table: "ArticleToTopics",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectToTopics_TopicId",
                table: "SubjectToTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleToTopics");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "SubjectToTopics");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
