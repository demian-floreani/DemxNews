using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class up2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Subjects_GroupingId",
                table: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Grouping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grouping",
                table: "Grouping",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Grouping_GroupingId",
                table: "Article",
                column: "GroupingId",
                principalTable: "Grouping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Grouping_GroupingId",
                table: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grouping",
                table: "Grouping");

            migrationBuilder.RenameTable(
                name: "Grouping",
                newName: "Subjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Subjects_GroupingId",
                table: "Article",
                column: "GroupingId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
