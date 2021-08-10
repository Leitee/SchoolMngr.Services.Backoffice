
namespace SchoolMngr.Services.Backoffice.DAL.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Backoffice.Model.Entities;

    public class AssignmentConfig : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("AssignmentID");
            builder.Property(e => e.From).IsRequired();
            builder.Property(e => e.To).IsRequired();

            builder
                .HasOne(a => a.Class)
                .WithMany(c => c.Assingments)
                .HasForeignKey(c => c.ClassId);
        }
    }
}
