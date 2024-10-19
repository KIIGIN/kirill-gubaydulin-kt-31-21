using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace kirill_gubaydulin_kt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_degree",
                columns: table => new
                {
                    degree_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_degree_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_degree_degree_id", x => x.degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_load",
                columns: table => new
                {
                    load_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_hours = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_load_load_id", x => x.load_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_position_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    dt_founding_time = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    lead_id = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    c_teacher_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    c_teacher_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    department_id = table.Column<int>(type: "int4", nullable: true),
                    position_id = table.Column<int>(type: "int4", nullable: true),
                    degree_id = table.Column<int>(type: "int4", nullable: true),
                    discipline_id = table.Column<int>(type: "int4", nullable: true),
                    load_id = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "FK_cd_teacher_cd_load_load_id",
                        column: x => x.load_id,
                        principalTable: "cd_load",
                        principalColumn: "load_id");
                    table.ForeignKey(
                        name: "fk_degree_id",
                        column: x => x.degree_id,
                        principalTable: "cd_degree",
                        principalColumn: "degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_department_id",
                        column: x => x.department_id,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_position_id",
                        column: x => x.position_id,
                        principalTable: "cd_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_fk_lead_id",
                table: "cd_department",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_department_lead_id",
                table: "cd_department",
                column: "lead_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_degree_id",
                table: "cd_teacher",
                column: "degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_department_id",
                table: "cd_teacher",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_discipline_id",
                table: "cd_teacher",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_load_id",
                table: "cd_teacher",
                column: "load_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_position_id",
                table: "cd_teacher",
                column: "position_id");

            migrationBuilder.AddForeignKey(
                name: "fk_lead_id",
                table: "cd_department",
                column: "lead_id",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_lead_id",
                table: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_load");

            migrationBuilder.DropTable(
                name: "cd_degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
