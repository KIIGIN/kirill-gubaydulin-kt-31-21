using kirill_gubaydulin_kt_31_21.Database.Helpers;
using kirill_gubaydulin_kt_31_21.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace kirill_gubaydulin_kt_31_21.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                .HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd()
                .HasColumnName("discipline_id");

            builder.Property(p => p.DisciplineName)
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            // Teacher
            builder.Property(p => p.TeacherId)
                .HasColumnName("teacher_id");

            builder.HasOne(p => p.Teacher)
                .WithMany()
                .HasForeignKey(p => p.TeacherId)
                .HasConstraintName("fk_teacher_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(
                p => p.TeacherId, $"idx_{TableName}_fk_teacher_id"
            );

            builder.Navigation(p => p.Teacher)
                .AutoInclude();

            builder.ToTable(TableName);
        }
    }
}