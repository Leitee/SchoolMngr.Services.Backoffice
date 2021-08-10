using AutoMapper;
using Fitnner.Trainers.Catalog.Model.Dtos;
using Fitnner.Trainers.Catalog.Model.Entities;
using Pandora.NetStdLibrary.Base.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitnner.Trainers.Catalog.BL.Mappers
{
    public class CategoryMapper : GenericMapper<Category, CategoryDTO>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                //c.ForAllMaps((typeMap, mappingExpression) => mappingExpression.MaxDepth(2));
                //c.CreateMap<TEntity, TDto>().MaxDepth(2);
                c.AllowNullCollections = true;
                c.CreateMap<Category, CategoryDTO>().MaxDepth(2).ReverseMap();
                c.CreateMap<Subject, SubjectDto>().MaxDepth(2).ReverseMap();
            }).CreateMapper();
        }
    }
}
