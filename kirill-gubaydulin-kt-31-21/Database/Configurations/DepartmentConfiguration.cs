using kirill_gubaydulin_kt_31_21.Database.Helpers;
using kirill_gubaydulin_kt_31_21.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace kirill_gubaydulin_kt_31_21.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(p => p.DepartmentId)
                .HasName($"pk_{TableName}_department_id");

            builder.Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("department_id");

            builder.Property(p => p.DepartmentName)
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.ToTable(TableName);
        }
    }
}
