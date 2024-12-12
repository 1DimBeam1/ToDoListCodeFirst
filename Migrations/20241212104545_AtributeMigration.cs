using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AtributeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ToDoList_ToDoListlistId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ToDoListlistId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ToDoListlistId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "listId",
                table: "ToDoList",
                newName: "listID");

            migrationBuilder.RenameColumn(
                name: "user",
                table: "ToDoList",
                newName: "userID");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "taskID",
                table: "ToDoList",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "taskName",
                table: "Tasks",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "taskDescription",
                table: "Tasks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "taskID",
                table: "ToDoList");

            migrationBuilder.RenameColumn(
                name: "listID",
                table: "ToDoList",
                newName: "listId");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "ToDoList",
                newName: "user");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "taskName",
                table: "Tasks",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "taskDescription",
                table: "Tasks",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "ToDoListlistId",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ToDoListlistId",
                table: "Tasks",
                column: "ToDoListlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ToDoList_ToDoListlistId",
                table: "Tasks",
                column: "ToDoListlistId",
                principalTable: "ToDoList",
                principalColumn: "listId");
        }
    }
}
