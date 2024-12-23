﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using kirill_gubaydulin_kt_31_21.Database;

#nullable disable

namespace kirill_gubaydulin_kt_31_21.Migrations
{
    [DbContext(typeof(DepartmentDbContext))]
    [Migration("20241025162619_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("kirill_gubaydulin_kt_31_21.Models.Degree", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("degree_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DegreeId"));

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_degree_name");

                    b.HasKey("DegreeId")
                        .HasName("pk_cd_degree_degree_id");

                    b.ToTable("cd_degree", (string)null);
                });

            modelBuilder.Entity("kirill_gubaydulin_kt_31_21.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("department_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_department_name");

                    b.Property<DateTime>("FoundingTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("dt_founding_time")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int?>("LeadId")
                        .HasColumnType("int4")
                        .HasColumnName("lead_id");

                    b.HasKey("DepartmentId")
                        .HasName("pk_cd_department_department_id");

                    b.HasIndex("LeadId")
                        .IsUnique();

                    b.HasIndex(new[] { "LeadId" }, "idx_cd_department_fk_lead_id");

                    b.ToTable("cd_department", (string)null);
                });

            modelBuilder.Entity("kirill_gubaydulin_kt_31_21.Models.Discipline", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("discipline_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DisciplineId"));

                    b.Property<string>("DisciplineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_discipline_name");

                    b.HasKey("DisciplineId")
                        .HasName("pk_cd_discipline_discipline_id");

                    b.ToTable("cd_discipline", (string)null);
                });

            modelBuilder.Entity("kirill_gubaydulin_kt_31_21.Models.Load", b =>
                {
                    b.Property<int>("LoadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("load_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LoadId"));

                    b.Property<int>("Hours")
                        .HasColumnType("int4")
                        .HasColumnName("c_hours");

                    b.HasKey("LoadId")
                        .HasName("pk_cd_load_load_id");

                    b.ToTable("cd_load", (string)null);
                });

            modelBuilder.Entity("kirill_gubaydulin_kt_31_21.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("position_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PositionId"));

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_position_name");

                    b.HasKey("PositionId")
                        .HasName("pk_cd_position_position_id");

                    b.ToTable("cd_position", (string)null);
                });

            modelBuilder.Entity("kirill_gubaydulin_kt_31_21.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeacherId"));

                    b.Property<int?>("DegreeId")
                        .HasColumnType("int4")
                        .HasColumnName("degree_id");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int4")
                        .HasColumnName("department_id");

                    b.Property<int?>("DisciplineId")
                        .HasColumnType("int4")
                        .HasColumnName("discipline_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_firstname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_lastname");

                    b.Property<int?>("LoadId")
                        .HasColumnType("int4")
                        .HasColumnName("load_id");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_middlename");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int4")
                        .HasColumnName("position_id");

                    b.HasKey("TeacherId")
                        .HasName("pk_cd_teacher_teacher_id");

                    b.HasIndex(new[] { "DegreeId" }, "idx_cd_teacher_fk_degree_id");

                    b.HasIndex(new[] { "DepartmentId" }, "idx_cd_teacher_fk_department_id");

                    b.HasIndex(new[] { "DisciplineId" }, "idx_cd_teacher_fk_discipline_id");

                    b.HasIndex(new[] { "LoadId" }, "idx_cd_teacher_fk_load_id");

                    b.HasIndex(new[] { "PositionId" }, "idx_cd_teacher_fk_position_id");

                    b.ToTable("cd_teacher", (string)null);
                });

            modelBuilder.Entity("kirill_gubaydulin_kt_31_21.Models.Department", b =>
                {
                    b.HasOne("kirill_gubaydulin_kt_31_21.Models.Teacher", "Leader")
                        .WithOne()
                        .HasForeignKey("kirill_gubaydulin_kt_31_21.Models.Department", "LeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_lead_id");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("kirill_gubaydulin_kt_31_21.Models.Teacher", b =>
                {
                    b.HasOne("kirill_gubaydulin_kt_31_21.Models.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_degree_id");

                    b.HasOne("kirill_gubaydulin_kt_31_21.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_department_id");

                    b.HasOne("kirill_gubaydulin_kt_31_21.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_discipline_id");

                    b.HasOne("kirill_gubaydulin_kt_31_21.Models.Load", "Load")
                        .WithMany()
                        .HasForeignKey("LoadId");

                    b.HasOne("kirill_gubaydulin_kt_31_21.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_position_id");

                    b.Navigation("Degree");

                    b.Navigation("Department");

                    b.Navigation("Discipline");

                    b.Navigation("Load");

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
