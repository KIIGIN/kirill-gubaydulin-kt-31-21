using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kirill_gubaydulin_kt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FoundingTime",
                table: "cd_department",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "cd_department",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_fk_teacher_id",
                table: "cd_department",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "fk_teacher_id",
                table: "cd_department",
                column: "TeacherId",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_teacher_id",
                table: "cd_department");

            migrationBuilder.DropIndex(
                name: "idx_cd_department_fk_teacher_id",
                table: "cd_department");

            migrationBuilder.DropColumn(
                name: "FoundingTime",
                table: "cd_department");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "cd_department");
        }
    }
}
