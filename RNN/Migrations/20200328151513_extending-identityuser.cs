using Microsoft.EntityFrameworkCore.Migrations;

namespace RNN.Migrations
{
    public partial class extendingidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AspNetUsers_IdentityUserId",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Entries",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_IdentityUserId",
                table: "Entries",
                newName: "IX_Entries_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AspNetUsers_ApplicationUserId",
                table: "Entries",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AspNetUsers_ApplicationUserId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Entries",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_ApplicationUserId",
                table: "Entries",
                newName: "IX_Entries_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AspNetUsers_IdentityUserId",
                table: "Entries",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
