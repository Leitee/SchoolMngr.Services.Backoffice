/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Entities
{
    using Pandora.NetStdLibrary.Base.DomainModel;
    using System;

    public class Assingment : AuditableEntity
    {
        public DateTime StartsTime { get; set; }
        public DateTime EndsTime { get; set; }

        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
