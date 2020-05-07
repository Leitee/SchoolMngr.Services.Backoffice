using SchoolMngr.BackOffice.Model.Enums;
using SchoolMngr.NetStdLibrary.Base.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMngr.BackOffice.Model.Entities
{
    [Table("StudentStates", Schema = "School")]
    public class StudentState : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual StudentStateEnum AcademicState { get; set; }
        [Required]
        public virtual DateTime DateFrom { get; set; }
        public virtual DateTime? DateTo { get; set; }
        public virtual int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual string Obs { get; set; }
    }
}
