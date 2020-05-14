/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL.ModelConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.BackOffice.Model.Entities;

    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects", "BO");
            builder.Property(e => e.Id).HasColumnName("SubjectID");
            builder.Property(e => e.CodeName).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            //builder.HasOne(s => s.Required).WithOne(rs => rs.Required)
            //    .HasForeignKey<Subject>(x => x.RequiredId);
            builder.Property(e => e.MaxAbsencesAllowed).HasDefaultValue(3);
            builder.Property(e => e.MinExamScoreRequired).HasDefaultValue(6);
        }
    }
}
