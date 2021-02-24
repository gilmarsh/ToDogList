using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDogList.Migrations
{
    public partial class relationalTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ToDoItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_UserId",
                table: "ToDoItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_AspNetUsers_UserId",
                table: "ToDoItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_AspNetUsers_UserId",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_UserId",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ToDoItems");
        }
    }
}
