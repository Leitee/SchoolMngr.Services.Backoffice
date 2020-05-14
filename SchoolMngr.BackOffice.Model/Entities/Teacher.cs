/// <summary>
/// 
/// </summary>
namespace SchoolMngr.BackOffice.Model.Entities
{
    using Pandora.NetStdLibrary.Base.Abstractions.DomainModel;
    using Pandora.NetStdLibrary.Base.DomainModel;
    using System.Collections.Generic;

    public class Teacher : EFEntity, ITrackeableEntity
    {
        public bool Deleted { get; set; }
        public string Address { get; set; }
        public bool IsTemporary { get; set; }
        public string Obs { get; set; }

        public virtual int IdentityUserId { get; set; }

        public virtual ICollection<Assingment> Assingments { get; set; }

    }
}
