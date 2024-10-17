using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kirill_gubaydulin_kt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_cd_load_load_id",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "cd_teacher");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_teacher_cd_load_load_id",
                table: "cd_teacher",
                column: "load_id",
                principalTable: "cd_load",
                principalColumn: "load_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_teacher_cd_load_load_id",
                table: "cd_teacher");

            migrationBuilder.RenameTable(
                name: "cd_teacher",
                newName: "Teachers");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_cd_load_load_id",
                table: "Teachers",
                column: "load_id",
                principalTable: "cd_load",
                principalColumn: "load_id");
        }
    }
}
