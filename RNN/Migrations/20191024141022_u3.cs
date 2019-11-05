using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class u3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryToTopics_Entry_ArticleId",
                table: "EntryToTopics");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "EntryToTopics",
                newName: "EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryToTopics_ArticleId",
                table: "EntryToTopics",
                newName: "IX_EntryToTopics_EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryToTopics_Entry_EntryId",
                table: "EntryToTopics",
                column: "EntryId",
                principalTable: "Entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryToTopics_Entry_EntryId",
                table: "EntryToTopics");

            migrationBuilder.RenameColumn(
                name: "EntryId",
                table: "EntryToTopics",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryToTopics_EntryId",
                table: "EntryToTopics",
                newName: "IX_EntryToTopics_ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryToTopics_Entry_ArticleId",
                table: "EntryToTopics",
                column: "ArticleId",
                principalTable: "Entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
