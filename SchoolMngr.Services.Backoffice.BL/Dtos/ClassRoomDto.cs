﻿
namespace SchoolMngr.Services.Backoffice.BL.Dtos
{
    using Codeit.Enterprise.Base.Abstractions.BusinessLogic;
    using System;

    public class ClassRoomDto : IDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public short Capacity { get; set; }
        public bool? HasNetworkConexion { get; set; }
        public bool? HasScreenProjector { get; set; }
    }
}
