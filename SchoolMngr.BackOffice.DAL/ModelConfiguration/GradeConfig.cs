/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL.ModelConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.BackOffice.Model.Entities;

    public class GradeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("Grades", "BO");
            builder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("GradeID");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        }
    }
}
