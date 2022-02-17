
namespace SchoolMngr.Services.Backoffice.BL.Dtos
{
    using Codeit.Enterprise.Base.Abstractions.BusinessLogic;
    using System;

    public sealed class EnrollmentDto : IDto
    {
        public Guid Id { get; set; }
        public string StudentProfileId { get; set; }

        public string StudentStatus { get; set; }

        public ClassDto Class { get; set; }
    }
}
