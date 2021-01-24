/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL.ModelConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.BackOffice.Model.Entities;

    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers", "BO");
            builder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("TeacherID");
            builder.Property(e => e.Address).HasMaxLength(200);
        }
    }
}
