﻿
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using System.Collections.Generic;

    public class Grade : Entity<int>
    {
        public string Name { get; set; }

        public virtual ISet<Subject> Subjects { get; set; }
    }
}
