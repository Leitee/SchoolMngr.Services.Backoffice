using Newtonsoft.Json;
using SchoolMngr.BackOffice.Model.Enums;
using Pandora.NetStdLibrary.Base.DomainModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SchoolMngr.BackOffice.Model.Entities
{
    public class Class : AuditableEntity
    {
        public string Name { get; set; }
        public ShiftTimeEnum Shift { get; set; }
        public DateTime StartsDate { get; set; }
        public DateTime ClosesDate { get; set; }
        public short EnrolledQty { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual int AssingmentId { get; set; }
        public virtual Assingment Assingment { get; set; }
        public virtual int ClassRoomId { get; set; }
        public virtual Room ClassRoom { get; set; }
    }
}
