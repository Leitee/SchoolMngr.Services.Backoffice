
namespace SchoolMngr.Services.Backoffice.DAL.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Backoffice.Model.Entities;

    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers", "DOMAIN");
            builder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("TeacherID");
            builder.Property(e => e.Address).HasMaxLength(200);
        }
    }
}
