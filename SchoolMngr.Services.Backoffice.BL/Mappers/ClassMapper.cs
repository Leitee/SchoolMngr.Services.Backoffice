namespace SchoolMngr.Services.Backoffice.BL.Mappers
{
    using AutoMapper;
    using Codeit.Enterprise.Base.BusinessLogic;
    using SchoolMngr.Services.Backoffice.BL.Dtos;
    using SchoolMngr.Services.Backoffice.Model.Entities;

    public class ClassMapper : GenericMapper<Class, ClassDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return new MapperConfiguration(delegate (IMapperConfigurationExpression c)
            {
                c.CreateMap<ClassRoom, ClassRoomDto>().MaxDepth(2).ReverseMap();
            }).CreateMapper();
        }
    }
}
