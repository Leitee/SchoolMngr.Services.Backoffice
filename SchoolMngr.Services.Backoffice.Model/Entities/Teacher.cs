
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Codeit.NetStdLibrary.Base.DomainModel;
    using System;
    using System.Collections.Generic;

    public class Teacher : EFEntity, IDeleteableEntity
    {
        public string EmployeeNumber { get; set; }
        public bool Deleted { get; set; }
        public string Address { get; set; }
        public bool IsTemporary { get; set; }
        public string Observations { get; set; }

        public virtual Guid IdentityUserId { get; set; }

        public virtual ICollection<Assignment> Assingments { get; set; }

    }
}
