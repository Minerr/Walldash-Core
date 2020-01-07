using Microsoft.EntityFrameworkCore.Migrations;

namespace Walldash.EntityFramework.DataContext.Migrations.Core
{
    public partial class DashboardSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TextColor",
                table: "Widgets",
                nullable: false,
                defaultValue: "#000",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundColor",
                table: "Widgets",
                nullable: false,
                defaultValue: "#fff",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Dashboards",
                nullable: false,
                defaultValue: "#e7ecf2");

            migrationBuilder.AddColumn<int>(
                name: "Columns",
                table: "Dashboards",
                nullable: false,
                defaultValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "NavbarColor",
                table: "Dashboards",
                nullable: false,
                defaultValue: "#0f1723");

            migrationBuilder.AddColumn<int>(
                name: "Rows",
                table: "Dashboards",
                nullable: false,
                defaultValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "Columns",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "NavbarColor",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "Rows",
                table: "Dashboards");

            migrationBuilder.AlterColumn<string>(
                name: "TextColor",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "#000");

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundColor",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "#fff");
        }
    }
}
