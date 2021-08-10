
namespace SchoolMngr.Services.Backoffice.DAL.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Backoffice.Model.Entities;

    public class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("EnrollmentID");
            builder.Property(e => e.StudentProfileId).IsRequired().HasMaxLength(25);
            builder.Property(e => e.StudentStatus).IsRequired();

            builder
                .HasOne(e => e.Class)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClassId);
        }
    }
}
