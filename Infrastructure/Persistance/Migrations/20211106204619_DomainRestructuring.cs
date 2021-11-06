using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistance.Migrations
{
    public partial class DomainRestructuring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoComment");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "ImageTags");

            migrationBuilder.AddColumn<string>(
                name: "TagsCommaSeperated",
                table: "Snorkels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SnorkelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityInfos_Snorkels_SnorkelId",
                        column: x => x.SnorkelId,
                        principalTable: "Snorkels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SnorkelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionInfos_Snorkels_SnorkelId",
                        column: x => x.SnorkelId,
                        principalTable: "Snorkels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoryInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SnorkelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryInfos_Snorkels_SnorkelId",
                        column: x => x.SnorkelId,
                        principalTable: "Snorkels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInfos_SnorkelId",
                table: "ActivityInfos",
                column: "SnorkelId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionInfos_SnorkelId",
                table: "DescriptionInfos",
                column: "SnorkelId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryInfos_SnorkelId",
                table: "HistoryInfos",
                column: "SnorkelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityInfos");

            migrationBuilder.DropTable(
                name: "DescriptionInfos");

            migrationBuilder.DropTable(
                name: "HistoryInfos");

            migrationBuilder.DropColumn(
                name: "TagsCommaSeperated",
                table: "Snorkels");

            migrationBuilder.CreateTable(
                name: "ImageTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Info_ImageTags_ImageTagId",
                        column: x => x.ImageTagId,
                        principalTable: "ImageTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoComment_Info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Info_ImageTagId",
                table: "Info",
                column: "ImageTagId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoComment_InfoId",
                table: "InfoComment",
                column: "InfoId");
        }
    }
}
