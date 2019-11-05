using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class u11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 5, 17 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 6, 18 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 7, 19 });

            migrationBuilder.DeleteData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Entry");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Entry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Entry",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Author1");

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "GroupingId", "Rank", "Width" },
                values: new object[] { 1, 1, 12 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "GroupingId", "HeadLine", "Url", "Body", "Img", "Paragraph", "Rank", "TitleId", "Width" },
                values: new object[] { 1, "Article piece 1", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2, 2, 4 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "GroupingId", "HeadLine", "Rank", "Width" },
                values: new object[] { 1, "Article piece 2", 3, 4 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "GroupingId", "HeadLine", "Rank", "Width" },
                values: new object[] { 1, "Article piece 3", 4, 4 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "GroupingId", "HeadLine", "Rank", "TitleId", "Width" },
                values: new object[] { 1, "Article piece 4", 5, 5, 8 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "GroupingId", "HeadLine", "Rank", "TitleId" },
                values: new object[] { 1, "Article piece 5", 5, 6 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "GroupingId", "HeadLine", "Rank", "TitleId", "Width" },
                values: new object[] { 1, "Article piece 6", 6, 4, 4 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "GroupingId", "HeadLine" },
                values: new object[] { 2, "Article piece 7" });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "GroupingId", "HeadLine", "Body", "Img", "Paragraph", "TitleId" },
                values: new object[] { 2, "Over 350 migrants on NGO ship Ocean Viking after new rescue in Mediterranean", "", "viking.jpg", "", 9 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "GroupingId", "HeadLine", "Url", "Img", "Paragraph", "TitleId" },
                values: new object[] { 2, "MPs debate Boris Johnson's deal as People's Vote march sets off – live Article", "", "Article.jpg", "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 1 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 1,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 2,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 3,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 4,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 5,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 6,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 7,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 8,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 9,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 10,
                column: "GroupingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 11,
                column: "GroupingId",
                value: 1);

            migrationBuilder.InsertData(
                table: "EntryToTopics",
                columns: new[] { "TopicId", "EntryId" },
                values: new object[,]
                {
                    { 1, 19 },
                    { 7, 18 },
                    { 6, 17 },
                    { 4, 15 },
                    { 3, 14 },
                    { 1, 13 },
                    { 2, 21 },
                    { 5, 16 }
                });

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Type" },
                values: new object[] { "", "Headlines" });

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Type" },
                values: new object[] { "EU Migrant Crisis", "In Focus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "EntryToTopics",
                keyColumns: new[] { "TopicId", "EntryId" },
                keyValues: new object[] { 7, 18 });

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Entry");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Entry");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Entry",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Autho1");

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "GroupingId", "HeadLine", "IsFeatured", "Url", "Body", "Img", "Paragraph", "TitleId" },
                values: new object[] { null, "MPs debate Boris Johnson's deal as People's Vote march sets off – live Article", true, "", "", "Article.jpg", "Leadership campaign falters as he refuses to respond to questions at hustings about late-night argument with Carrie Symonds", 1 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "GroupingId", "HeadLine", "IsFeatured" },
                values: new object[] { null, "Article piece 1", true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "GroupingId", "HeadLine", "IsFeatured" },
                values: new object[] { null, "Article piece 2", true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "GroupingId", "HeadLine", "IsFeatured", "TitleId" },
                values: new object[] { null, "Article piece 3", true, 2 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "GroupingId", "HeadLine", "TitleId" },
                values: new object[] { null, "Article piece 4", 2 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "GroupingId", "HeadLine", "TitleId" },
                values: new object[] { null, "Article piece 5", 2 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "GroupingId", "HeadLine" },
                values: new object[] { null, "Article piece 6" });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "GroupingId", "HeadLine", "Body", "Img", "Paragraph", "TitleId" },
                values: new object[] { null, "Article piece 7", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "nature.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", 2 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "GroupingId", "HeadLine", "Url", "Img", "Paragraph", "TitleId" },
                values: new object[] { 1, "Over 350 migrants on NGO ship Ocean Viking after new rescue in Mediterranean", null, "viking.jpg", "", 9 });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "Entry",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "GroupingId", "IsFeatured" },
                values: new object[] { null, true });

            migrationBuilder.InsertData(
                table: "EntryToTopics",
                columns: new[] { "TopicId", "EntryId" },
                values: new object[,]
                {
                    { 1, 21 },
                    { 7, 19 },
                    { 5, 17 },
                    { 4, 16 },
                    { 3, 15 },
                    { 2, 14 },
                    { 1, 14 },
                    { 6, 18 }
                });

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Type" },
                values: new object[] { "EU Migrant Crisis", "In Focus" });

            migrationBuilder.UpdateData(
                table: "Grouping",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Grouping 2", null });

            migrationBuilder.InsertData(
                table: "Grouping",
                columns: new[] { "Id", "Name", "Rank", "Type" },
                values: new object[,]
                {
                    { 4, "Grouping 4", 4, null },
                    { 3, "Grouping 3", 3, null }
                });
        }
    }
}
