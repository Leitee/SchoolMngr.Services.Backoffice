
namespace SchoolMngr.Services.Backoffice.BL.Dtos
{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using SchoolMngr.Services.Backoffice.Model.Enums;
    using System;

    public sealed class EnrollmentDto : IDto
    {
        public Guid Id { get; set; }
        public string StudentProfileId { get; set; }

        public StudentStatusEnum StudentStatus { get; set; }

        public ClassDto Class { get; set; }
    }
}
