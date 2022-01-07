using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfThisUp.Migrations
{
    public partial class AddedStuff22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPosts_AspNetUsers_OwnerId",
                table: "RentalPosts");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "RentalPosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPosts_AspNetUsers_OwnerId",
                table: "RentalPosts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalPosts_AspNetUsers_OwnerId",
                table: "RentalPosts");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "RentalPosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalPosts_AspNetUsers_OwnerId",
                table: "RentalPosts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
