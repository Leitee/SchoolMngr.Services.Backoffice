﻿
namespace SchoolMngr.Services.Backoffice.Model.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using System;

    public class Assignment : AuditableEntity
    {
        public DateTime From { get; set; }
        public DateTime? To { get; set; }

        public Guid ClassId { get; set; }
        public virtual Class Class { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
