
namespace SchoolMngr.Services.Backoffice.DAL.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Backoffice.Model.Entities;

    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("ClassID");
            builder.Property(e => e.DivisionName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.StartsAt).IsRequired();
        }
    }
}
