
namespace SchoolMngr.Services.Backoffice.DAL.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Model.Entities;

    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("SubjectID");
            builder.Property(e => e.CodeName).IsRequired().HasMaxLength(10);
            builder.Property(e => e.FullName).IsRequired().HasMaxLength(50);

            builder
                .HasOne(s => s.NextAvailable)
                .WithMany(rs => rs.PreviousRequired).IsRequired(false)
                .HasForeignKey(x => x.NextAvailableId);

            builder
                .HasOne(s => s.Class)
                .WithOne(c => c.Subject)
                .HasForeignKey<Class>(c => c.SubjectId);

            builder
                .HasOne(s => s.Grade)
                .WithMany(g => g.Subjects)
                .HasForeignKey(g => g.GradeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.MaxAbsencesAllowed).HasDefaultValue(3);
            builder.Property(e => e.MinExamScoreRequired).HasDefaultValue(6);
        }
    }
}
