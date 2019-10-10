using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class InitialCreate : Migration
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
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
                name: "Editorials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Paragraph = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Editorials_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Paragraph = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostToTopics",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostToTopics", x => new { x.TopicId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostToTopics_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostToTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "OpinionToTopic",
                columns: table => new
                {
                    OpinionId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpinionToTopic", x => new { x.TopicId, x.OpinionId });
                    table.ForeignKey(
                        name: "FK_OpinionToTopic_Opinions_OpinionId",
                        column: x => x.OpinionId,
                        principalTable: "Opinions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpinionToTopic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "RenegadeNews" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Date", "IsFeatured", "Title", "Url" },
                values: new object[,]
                {
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test post: put all the content here for the post title 8", "" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test post: put all the content here for the post title 7", "" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test post: put all the content here for the post title 6", "" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test post: put all the content here for the post title 5", "" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test post: put all the content here for the post title 4", "" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test post: put all the content here for the post title 3", "" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test post: put all the content here for the post title 2", "" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test post: put all the content here for the post title 1", "" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "U.S. Economy Grew 3.1% in First Quarter", "" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Barr: Mueller could have reached a decision on obstruction", "" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "White House launches tool to report censorship on Facebook", "" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bye-bye Bolton?", "" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Merkel Attacks Trump in Harvard Speech", "" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "RON PAUL: US/UK Trying To Kill Assange?", "" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Journalists Detained During First Day of Bilderberg", "" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Donald Trump: 'I Got Me Elected'", "" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "Rank" },
                values: new object[,]
                {
                    { 5, "Deep State", 5 },
                    { 4, "Free Speech", 4 },
                    { 2, "Boom & Bust", 2 },
                    { 1, "Migration", 1 },
                    { 3, "Climate Activism", 3 }
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
                    { 25, "Tech Fascism" },
                    { 27, "Big Brother" },
                    { 28, "Wikipedia" },
                    { 29, "Viktor Orban" },
                    { 30, "Salvini" },
                    { 31, "Junker" },
                    { 26, "First Amendment" },
                    { 17, "RINOs" },
                    { 6, "EU" },
                    { 15, "Merkel" },
                    { 1, "Brexit" },
                    { 2, "Deep State" },
                    { 3, "Corruption" },
                    { 4, "Money in Politics" },
                    { 5, "Donald Trump" },
                    { 32, "Refugees" },
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
                table: "Editorials",
                columns: new[] { "Id", "AuthorId", "Body", "Img", "IsFeatured", "Paragraph", "Title", "Url" },
                values: new object[] { 1, 1, "", "", true, "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", "Boris Johnson under fire over row with partner as top Tories raise fears", "" });

            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "Id", "AuthorId", "Body", "Img", "IsFeatured", "Paragraph", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", "How the Right Must Embrace Environmen- talism" },
                    { 2, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", "Opinion piece 2" },
                    { 3, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", "Opinion piece 3" },
                    { 4, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", "Opinion piece 4" },
                    { 5, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", "Opinion piece 5" },
                    { 6, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", "Opinion piece 6" },
                    { 7, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", "Opinion piece 7" }
                });

            migrationBuilder.InsertData(
                table: "PostToTopics",
                columns: new[] { "TopicId", "PostId" },
                values: new object[,]
                {
                    { 30, 10 },
                    { 29, 9 },
                    { 25, 5 },
                    { 19, 7 },
                    { 16, 4 },
                    { 15, 3 },
                    { 2, 15 },
                    { 5, 8 },
                    { 2, 16 },
                    { 31, 11 },
                    { 2, 14 },
                    { 2, 13 },
                    { 2, 2 },
                    { 8, 1 },
                    { 33, 12 }
                });

            migrationBuilder.InsertData(
                table: "OpinionToTopic",
                columns: new[] { "TopicId", "OpinionId" },
                values: new object[,]
                {
                    { 30, 4 },
                    { 29, 5 },
                    { 5, 6 },
                    { 2, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Editorials_AuthorId",
                table: "Editorials",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_AuthorId",
                table: "Opinions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_OpinionToTopic_OpinionId",
                table: "OpinionToTopic",
                column: "OpinionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostToTopics_PostId",
                table: "PostToTopics",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectToTopics_TopicId",
                table: "SubjectToTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Editorials");

            migrationBuilder.DropTable(
                name: "OpinionToTopic");

            migrationBuilder.DropTable(
                name: "PostToTopics");

            migrationBuilder.DropTable(
                name: "SubjectToTopics");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
