using kirill_gubaydulin_kt_31_21.Database.Helpers;
using kirill_gubaydulin_kt_31_21.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace kirill_gubaydulin_kt_31_21.Database.Configurations
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        private const string TableName = "cd_degree";

        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder
                .HasKey(p => p.DegreeId)
                .HasName($"pk_{TableName}_degree_id");

            builder.Property(p => p.DegreeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("degree_id");

            builder.Property(p => p.DegreeName)
                .HasColumnName("c_degree_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.ToTable(TableName);
        }
    }
}