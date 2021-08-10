
namespace SchoolMngr.Services.Backoffice.DAL.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Backoffice.Model.Entities;

    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("Grades", "DOMAIN");
            builder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("GradeID");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);

            builder
                .HasMany(g => g.Subjects)
                .WithOne(s => s.Grade)
                .HasForeignKey(s => s.GradeId);
        }
    }
}
