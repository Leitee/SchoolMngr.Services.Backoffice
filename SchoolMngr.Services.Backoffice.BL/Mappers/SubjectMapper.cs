namespace SchoolMngr.Services.Backoffice.BL.Mappers
{
    using AutoMapper;
    using Codeit.Enterprise.Base.BusinessLogic;
    using SchoolMngr.Services.Backoffice.BL.Dtos;
    using SchoolMngr.Services.Backoffice.Model.Entities;

    public class SubjectMapper : GenericMapper<Subject, SubjectDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return new MapperConfiguration(delegate (IMapperConfigurationExpression c)
            {
                c.CreateMap<Subject, SubjectDto>().MaxDepth(2).ReverseMap();
                c.CreateMap<Grade, GradeDto>().MaxDepth(2).ReverseMap();
                c.CreateMap<Class, ClassDto>().MaxDepth(2).ReverseMap();
            }).CreateMapper();
        }
    }
}
