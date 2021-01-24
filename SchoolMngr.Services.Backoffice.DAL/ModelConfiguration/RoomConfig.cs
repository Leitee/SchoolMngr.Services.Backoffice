/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.DAL.ModelConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.BackOffice.Model.Entities;

    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("ClassRooms", "BO");
            builder.Property(e => e.Id).HasColumnName("ClassRoomID");
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Capacity).IsRequired();
        }
    }
}
