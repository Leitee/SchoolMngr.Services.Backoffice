
namespace SchoolMngr.Services.Backoffice.BL.Dtos
{
    using Codeit.Enterprise.Base.Abstractions.BusinessLogic;
    using SchoolMngr.Services.Backoffice.Model.Enums;
    using System;
    using System.Collections.Generic;

    public  sealed class ClassDto : IDto
    {

        public ClassDto()
        {
            Assingments = new List<AssignmentDto>();
            Enrollments = new List<EnrollmentDto>();
        }
        public Guid Id { get; set; }
        public string DivisionName { get; set; }
        public ShiftTimeEnum Shift { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public DayOfWeek Day { get; set; }
        public short EnrolledQty { get; set; }
        public bool Deleted { get; set; }

        public SubjectDto Subject { get; set; }

        public ClassRoomDto ClassRoom { get; set; }

        public ICollection<AssignmentDto> Assingments { get; set; }
        public ICollection<EnrollmentDto> Enrollments { get; set; }
    }
}
