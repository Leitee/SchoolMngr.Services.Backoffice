
namespace SchoolMngr.Services.Backoffice.DAL.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Model.Entities;

    public class ClassRoomConfig : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.ToTable("ClassRooms", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("ClassRoomID");
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            builder.Property(e => e.MaxCapacity).IsRequired();

            builder
                .HasMany(cr => cr.Classes)
                .WithOne(c => c.ClassRoom)
                .HasForeignKey(c => c.ClassRoomId);
        }
    }
}
