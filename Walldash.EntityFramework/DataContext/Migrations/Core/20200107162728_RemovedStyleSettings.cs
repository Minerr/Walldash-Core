using Microsoft.EntityFrameworkCore.Migrations;

namespace Walldash.EntityFramework.DataContext.Migrations.Core
{
    public partial class RemovedStyleSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StyleSettings");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Widgets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TextColor",
                table: "Widgets",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "TextColor",
                table: "Widgets");

            migrationBuilder.CreateTable(
                name: "StyleSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WidgetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StyleSettings_Widgets_WidgetId",
                        column: x => x.WidgetId,
                        principalTable: "Widgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StyleSettings_WidgetId",
                table: "StyleSettings",
                column: "WidgetId",
                unique: true);
        }
    }
}
