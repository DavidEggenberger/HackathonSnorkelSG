using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistance.Migrations
{
    public partial class Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Event",
                table: "HistoryInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "HistoryInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DescriptionInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActivityName",
                table: "ActivityInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Event",
                table: "HistoryInfos");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "HistoryInfos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DescriptionInfos");

            migrationBuilder.DropColumn(
                name: "ActivityName",
                table: "ActivityInfos");
        }
    }
}
