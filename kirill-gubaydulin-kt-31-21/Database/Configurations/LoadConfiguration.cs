using kirill_gubaydulin_kt_31_21.Database.Helpers;
using kirill_gubaydulin_kt_31_21.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace kirill_gubaydulin_kt_31_21.Database.Configurations
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        private const string TableName = "cd_load";

        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder
                .HasKey(p => p.LoadId)
                .HasName($"pk_{TableName}_load_id");

            builder.Property(p => p.LoadId)
                .ValueGeneratedOnAdd()
                .HasColumnName("load_id");

            builder.Property(p => p.Hours)
                .HasColumnName("c_hours")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName);
        }
    }
}
