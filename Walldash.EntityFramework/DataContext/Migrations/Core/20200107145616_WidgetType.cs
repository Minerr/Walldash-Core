using Microsoft.EntityFrameworkCore.Migrations;

namespace Walldash.EntityFramework.DataContext.Migrations.Core
{
    public partial class WidgetType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Widgets");

            migrationBuilder.AddColumn<string>(
                name: "widget_type",
                table: "Widgets",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "widget_type",
                table: "Widgets");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Widgets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
