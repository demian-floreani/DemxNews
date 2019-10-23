using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectToTopics");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupingId",
                table: "Article",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_GroupingId",
                table: "Article",
                column: "GroupingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Subjects_GroupingId",
                table: "Article",
                column: "GroupingId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Subjects_GroupingId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_GroupingId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "GroupingId",
                table: "Article");

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

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "Rank" },
                values: new object[] { 5, "Deep State", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectToTopics_TopicId",
                table: "SubjectToTopics",
                column: "TopicId");
        }
    }
}
