using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class setup : Migration
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Slug = table.Column<string>(nullable: true),
                    Paragraph = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    HeadLine = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PageViews = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Entries_AuthorId",
                table: "Entries",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_Slug",
                table: "Entries",
                column: "Slug",
                unique: true,
                filter: "[Slug] IS NOT NULL");

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
        }
    }
}
