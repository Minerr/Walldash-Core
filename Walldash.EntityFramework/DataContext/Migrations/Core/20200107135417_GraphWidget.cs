using Microsoft.EntityFrameworkCore.Migrations;

namespace Walldash.EntityFramework.DataContext.Migrations.Core
{
    public partial class GraphWidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GraphColor",
                table: "Widgets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraphType",
                table: "Widgets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraphValueX",
                table: "Widgets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraphValueY",
                table: "Widgets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Widgets",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraphColor",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "GraphType",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "GraphValueX",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "GraphValueY",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Widgets");
        }
    }
}
