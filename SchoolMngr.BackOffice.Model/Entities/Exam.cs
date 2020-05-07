using SchoolMngr.BackOffice.Model.Enums;
using SchoolMngr.NetStdLibrary.Base.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMngr.BackOffice.Model.Entities
{
    [Table("Exams", Schema = "School")]
    public class Exam : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual ExamTypeEnum ExamType { get; set; }
        [Required]
        public virtual float Score { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual string Obs { get; set; }
        public virtual int StudentId { get; set; }
        [NotMapped]
        public virtual Student Student { get; set; }
        public virtual int SubjectId { get; set; }
        [NotMapped]
        public virtual Subject Subject { get; set; }
    }
}
