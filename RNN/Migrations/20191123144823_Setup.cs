using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class Setup : Migration
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
                name: "Grouping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grouping", x => x.Id);
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
                name: "Entries",
                columns: table => new
                {
                    TitleId = table.Column<int>(nullable: true),
                    Paragraph = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeadLine = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    GroupingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_Grouping_GroupingId",
                        column: x => x.GroupingId,
                        principalTable: "Grouping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryToTopics",
                columns: table => new
                {
                    EntryId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryToTopics", x => new { x.TopicId, x.EntryId });
                    table.ForeignKey(
                        name: "FK_EntryToTopics_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryToTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Author1" });

            migrationBuilder.InsertData(
                table: "Grouping",
                columns: new[] { "Id", "Name", "Rank", "Type" },
                values: new object[] { 1, "", 1, "Headlines" });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Italian Politics" },
                    { 9, "Italian News" },
                    { 8, "EU Entry" },
                    { 6, "US Politics" },
                    { 7, "EU News" },
                    { 4, "UK Politics" },
                    { 3, "UK News" },
                    { 2, "Opinion" },
                    { 1, "Editorial" },
                    { 5, "US News" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Topic 8" },
                    { 12, "Topic 12" },
                    { 11, "Topic 11" },
                    { 10, "Topic 10" },
                    { 9, "Topic 9" },
                    { 7, "Topic 7" },
                    { 1, "Topic 1" },
                    { 5, "Topic 5" },
                    { 4, "Topic 4" },
                    { 3, "Topic 3" },
                    { 2, "Topic 2" },
                    { 13, "Topic 13" },
                    { 6, "Topic 6" },
                    { 14, "Topic 14" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_AuthorId",
                table: "Entries",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_GroupingId",
                table: "Entries",
                column: "GroupingId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_TitleId",
                table: "Entries",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryToTopics_EntryId",
                table: "EntryToTopics",
                column: "EntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryToTopics");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Grouping");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
