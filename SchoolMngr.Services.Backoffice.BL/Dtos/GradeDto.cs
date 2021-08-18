
namespace SchoolMngr.Services.Backoffice.BL.Dtos
{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using System.Collections.Generic;

    public sealed class GradeDto : IDto<int>
    {
        public GradeDto()
        {
            Subjects = new List<SubjectDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SubjectDto> Subjects { get; set; }
    }
}
