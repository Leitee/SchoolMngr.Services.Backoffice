
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Codeit.NetStdLibrary.Base.DomainModel;
    using SchoolMngr.Services.Backoffice.Model.Enums;
    using System;
    using System.Collections.Generic;

    public class Class : AuditableEntity, IDeleteableEntity
    {
        public string DivisionName { get; set; }
        public ShiftTimeEnum Shift { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public DayOfWeek Day { get; set; }
        public short EnrolledQty { get; set; }
        public bool Deleted { get; set; }

        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public Guid ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

        public virtual ICollection<Assignment> Assingments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
