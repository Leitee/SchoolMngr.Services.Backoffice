/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL.ModelConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.BackOffice.Model.Entities;

    public class AssingmentConfig : IEntityTypeConfiguration<Assingment>
    {
        public void Configure(EntityTypeBuilder<Assingment> builder)
        {
            builder.ToTable("Assingments", "BO");
            builder.Property(e => e.Id).HasColumnName("AssingmentID");
            builder.Property(e => e.StartsTime).IsRequired();
            builder.Property(e => e.EndsTime).IsRequired();
        }
    }
}
