using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistance.Migrations
{
    public partial class SnorkelNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInfos_Snorkels_SnorkelId",
                table: "ActivityInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionInfos_Snorkels_SnorkelId",
                table: "DescriptionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryInfos_Snorkels_SnorkelId",
                table: "HistoryInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "SnorkelId",
                table: "HistoryInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SnorkelId",
                table: "DescriptionInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SnorkelId",
                table: "ActivityInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInfos_Snorkels_SnorkelId",
                table: "ActivityInfos",
                column: "SnorkelId",
                principalTable: "Snorkels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionInfos_Snorkels_SnorkelId",
                table: "DescriptionInfos",
                column: "SnorkelId",
                principalTable: "Snorkels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryInfos_Snorkels_SnorkelId",
                table: "HistoryInfos",
                column: "SnorkelId",
                principalTable: "Snorkels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInfos_Snorkels_SnorkelId",
                table: "ActivityInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionInfos_Snorkels_SnorkelId",
                table: "DescriptionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryInfos_Snorkels_SnorkelId",
                table: "HistoryInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "SnorkelId",
                table: "HistoryInfos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SnorkelId",
                table: "DescriptionInfos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SnorkelId",
                table: "ActivityInfos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInfos_Snorkels_SnorkelId",
                table: "ActivityInfos",
                column: "SnorkelId",
                principalTable: "Snorkels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionInfos_Snorkels_SnorkelId",
                table: "DescriptionInfos",
                column: "SnorkelId",
                principalTable: "Snorkels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryInfos_Snorkels_SnorkelId",
                table: "HistoryInfos",
                column: "SnorkelId",
                principalTable: "Snorkels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
