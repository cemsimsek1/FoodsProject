using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodsProject.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Admins",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "roles",
                table: "Admins",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "pass",
                table: "Admins",
                newName: "AdminRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Admins",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "roles");

            migrationBuilder.RenameColumn(
                name: "AdminRoles",
                table: "Admins",
                newName: "pass");
        }
    }
}
