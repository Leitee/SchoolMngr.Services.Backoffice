/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Entities
{
    using Codeit.NetStdLibrary.Base.DomainModel;
    using System.Collections.Generic;

    public class Subject : EFEntity
    {
        public string CodeName { get; set; }
        public string Description { get; set; }

        public virtual int? PerRequiredId { get; set; }
        public virtual Subject PreRequired { get; set; }
        public virtual int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual ICollection<Assingment> Assingments { get; set; }


        //TODO: move to configuration file
        #region subject constrains
        public short MinAttendanceRequired { get; set; }
        public short MinExamScoreRequired { get; set; }

        #endregion
    }
}
