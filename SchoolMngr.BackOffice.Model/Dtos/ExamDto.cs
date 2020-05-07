using SchoolMngr.NetStdLibrary.Base.Utils;
using SchoolMngr.BackOffice.Model.Entities;
using SchoolMngr.BackOffice.Model.Enums;
using Reinforced.Typings.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMngr.BackOffice.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Exam")]
    public sealed class ExamDto : Exam
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override ExamTypeEnum ExamType { get => base.ExamType; set => base.ExamType = value; }
        public string ExamTypeDescription { get { return ExamType.GetDescription(); } }
        public override float Score { get => base.Score; set => base.Score = value; }
        public override DateTime? Date { get => base.Date; set => base.Date = value; }
        public override string Obs { get => base.Obs; set => base.Obs = value; }
        [Required]
        public override int StudentId { get => base.StudentId; set => base.StudentId = value; }
        [Required]
        public override int SubjectId { get => base.SubjectId; set => base.SubjectId = value; }
        public new StudentDto Student { get; set; }
        public new SubjectDto Subject { get; set; }
    }
}
