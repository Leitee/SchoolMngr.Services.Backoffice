
namespace SchoolMngr.Services.Model.Entities
{
    using Codeit.NetStdLibrary.Base.DomainModel;
    using System.Collections.Generic;

    public class Grade : Entity<int>
    {
        public string Name { get; set; }

        public virtual ISet<Subject> Subjects { get; set; }
    }
}
