
namespace SchoolMngr.Services.Backoffice.BL.Dtos
{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using System;
    using System.Collections.Generic;

    public sealed class TeacherDto : IDto
    {
        public TeacherDto()
        {
            Assingments = new List<AssignmentDto>();
        }

        public Guid Id { get; set; }
        public string EmployeeNumber { get; set; }
        public bool Deleted { get; set; }
        public string Address { get; set; }
        public bool IsTemporary { get; set; }
        public string Observations { get; set; }

        public Guid IdentityUserId { get; set; }

        public ICollection<AssignmentDto> Assingments { get; set; }
    }
}
