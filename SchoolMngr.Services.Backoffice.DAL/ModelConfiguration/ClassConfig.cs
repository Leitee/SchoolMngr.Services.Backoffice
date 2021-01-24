/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL.ModelConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.BackOffice.Model.Entities;

    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes", "BO");
            builder.Property(e => e.Id).HasColumnName("ClassID");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.StartsDate).IsRequired();
        }
    }
}
