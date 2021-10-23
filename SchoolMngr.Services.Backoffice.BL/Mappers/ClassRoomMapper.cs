namespace SchoolMngr.Services.Backoffice.BL.Mappers
{
    using AutoMapper;
    using Codeit.NetStdLibrary.Base.BusinessLogic;
    using SchoolMngr.Services.Backoffice.BL.Dtos;
    using SchoolMngr.Services.Backoffice.Model.Entities;

    public class ClassRoomMapper : GenericMapper<ClassRoom, ClassRoomDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return DefaultMapConfiguration();
        }
    }
}
