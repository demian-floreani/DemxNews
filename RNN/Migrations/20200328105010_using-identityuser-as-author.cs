using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class usingidentityuserasauthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Authors_AuthorId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_AuthorId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Entries");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Entries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_IdentityUserId",
                table: "Entries",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AspNetUsers_IdentityUserId",
                table: "Entries",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AspNetUsers_IdentityUserId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_IdentityUserId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Entries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Entries_AuthorId",
                table: "Entries",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Authors_AuthorId",
                table: "Entries",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
