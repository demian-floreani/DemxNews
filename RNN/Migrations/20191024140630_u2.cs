using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class u2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleToTopics_Entry_ArticleId",
                table: "ArticleToTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleToTopics_Topics_TopicId",
                table: "ArticleToTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleToTopics",
                table: "ArticleToTopics");

            migrationBuilder.RenameTable(
                name: "ArticleToTopics",
                newName: "EntryToTopics");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleToTopics_ArticleId",
                table: "EntryToTopics",
                newName: "IX_EntryToTopics_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryToTopics",
                table: "EntryToTopics",
                columns: new[] { "TopicId", "ArticleId" });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Editorial");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Opinion");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "UK News");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "US News");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "EU News");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Italian News");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryToTopics_Entry_ArticleId",
                table: "EntryToTopics",
                column: "ArticleId",
                principalTable: "Entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryToTopics_Topics_TopicId",
                table: "EntryToTopics",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryToTopics_Entry_ArticleId",
                table: "EntryToTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryToTopics_Topics_TopicId",
                table: "EntryToTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryToTopics",
                table: "EntryToTopics");

            migrationBuilder.RenameTable(
                name: "EntryToTopics",
                newName: "ArticleToTopics");

            migrationBuilder.RenameIndex(
                name: "IX_EntryToTopics_ArticleId",
                table: "ArticleToTopics",
                newName: "IX_ArticleToTopics_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleToTopics",
                table: "ArticleToTopics",
                columns: new[] { "TopicId", "ArticleId" });

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Article");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Article");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "UK Article");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "US Article");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "EU Politics");

            migrationBuilder.UpdateData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Italian Article");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleToTopics_Entry_ArticleId",
                table: "ArticleToTopics",
                column: "ArticleId",
                principalTable: "Entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleToTopics_Topics_TopicId",
                table: "ArticleToTopics",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
