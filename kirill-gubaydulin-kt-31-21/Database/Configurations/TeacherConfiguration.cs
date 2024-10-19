using kirill_gubaydulin_kt_31_21.Database.Helpers;
using kirill_gubaydulin_kt_31_21.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace kirill_gubaydulin_kt_31_21.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Teacher
            builder
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id");

            builder.Property(p => p.FirstName)
                .HasColumnName("c_teacher_firstname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .HasColumnName("c_teacher_lastname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_teacher_middlename")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            // Department
            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasColumnType(ColumnType.Int);

            builder.HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId)
                .HasConstraintName("fk_department_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(
                p => p.DepartmentId, $"idx_{TableName}_fk_department_id"
            );

            builder.Navigation(p => p.Department)
                .AutoInclude();

            // Position
            builder.Property(p => p.PositionId)
                .HasColumnName("position_id")
                .HasColumnType(ColumnType.Int);

            builder.HasOne(p => p.Position)
                .WithMany()
                .HasForeignKey(p => p.PositionId)
                .HasConstraintName("fk_position_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(
                p => p.PositionId, $"idx_{TableName}_fk_position_id"
            );

            builder.Navigation(p => p.Position)
                .AutoInclude();

            // Degree
            builder.Property(p => p.DegreeId)
                .HasColumnName("degree_id")
                .HasColumnType(ColumnType.Int);

            builder.HasOne(p => p.Degree)
                .WithMany()
                .HasForeignKey(p => p.DegreeId)
                .HasConstraintName("fk_degree_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(
                p => p.DegreeId, $"idx_{TableName}_fk_degree_id"
            );

            builder.Navigation(p => p.Degree)
                .AutoInclude();

            // Discipline
            builder.Property(p => p.DisciplineId)
                .HasColumnName("discipline_id")
                .HasColumnType(ColumnType.Int);

            builder.HasOne(p => p.Discipline)
                .WithMany()
                .HasForeignKey(p => p.DisciplineId)
                .HasConstraintName("fk_discipline_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(
                p => p.DisciplineId, $"idx_{TableName}_fk_discipline_id"
            );

            builder.Navigation(p => p.Discipline)
                .AutoInclude();

            // Load
            builder.Property(p => p.LoadId)
                .HasColumnName("load_id")
                .HasColumnType(ColumnType.Int);

            builder.HasIndex(
                p => p.LoadId, $"idx_{TableName}_fk_load_id"
            );

            builder.Navigation(p => p.Load)
                .AutoInclude();

            builder.ToTable(TableName);
        }
    }
}
