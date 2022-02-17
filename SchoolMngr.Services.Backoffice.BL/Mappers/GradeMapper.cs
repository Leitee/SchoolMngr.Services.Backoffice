using AutoMapper;
using Codeit.Enterprise.Base.BusinessLogic;
using SchoolMngr.Services.Backoffice.BL.Dtos;
using SchoolMngr.Services.Backoffice.Model.Entities;

namespace SchoolMngr.Services.Backoffice.BL.Mappers
{
    public class GradeMapper : GenericMapper<Grade, GradeDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return DefaultMapConfiguration();
        }
    }
}
