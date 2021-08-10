using AutoMapper;
using Fitnner.Trainers.Catalog.Model.Dtos;
using Fitnner.Trainers.Catalog.Model.Entities;
using Pandora.NetStdLibrary.Base.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitnner.Trainers.Catalog.BL.Mappers
{
    public class LabelMapper : GenericMapper<Label, LabelDTO>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return DefaultMapConfiguration();
        }
    }
}
